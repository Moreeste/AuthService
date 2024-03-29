﻿using Domain.Model.Response;
using Domain.Repository;
using Domain.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;

namespace Infrastructure.Middleware
{
    public class ApiLogMiddleware : IMiddleware
    {
        private readonly ILogger<ApiLogMiddleware> _logger;
        private readonly ILogRepository _logRepository;
        private readonly IUtilities _utilities;

        public ApiLogMiddleware(ILogger<ApiLogMiddleware> logger, ILogRepository logRepository, IUtilities utilities)
        {
            _logger = logger;
            _logRepository = logRepository;
            _utilities = utilities;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            var result = await ProcessHttpRequest(context, next);

            stopWatch.Stop();
            await SaveLog(result, stopWatch.Elapsed);
        }

        private async Task<ApiLogModel> ProcessHttpRequest(HttpContext context, RequestDelegate next)
        {
            var result = new ApiLogModel();
            result.JsonRequest = (await ReadRequestBody(context.Request)).Replace("\n", string.Empty);
            result.Path = context.Request.Path;
            result.Method = context.Request.Method;
            result.Ip = context.Connection.RemoteIpAddress?.ToString();
            result.Token = context.Request.Headers.Authorization.ToString();

            var originalBodyStream = context.Response.Body;
            using (var responseBody = new MemoryStream())
            {
                context.Response.Body = responseBody;

                await next(context);

                result.JsonResponse = (await ReadResponseBody(context.Response)).Replace("\n", string.Empty);
                result.StatusCode = context.Response.StatusCode;

                responseBody.Seek(0, SeekOrigin.Begin);
                await responseBody.CopyToAsync(originalBodyStream);
            }

            return result;
        }

        private async Task<string> ReadRequestBody(HttpRequest request)
        {
            request.EnableBuffering();
            using var reader = new StreamReader(request.Body, Encoding.UTF8, true, 1024, true);
            var body = await reader.ReadToEndAsync();
            request.Body.Seek(0, SeekOrigin.Begin);
            return body;
        }

        private async Task<string> ReadResponseBody(HttpResponse response)
        {
            response.Body.Seek(0, SeekOrigin.Begin);
            using var reader = new StreamReader(response.Body, Encoding.UTF8, true, 1024, true);
            var body = await reader.ReadToEndAsync();
            response.Body.Seek(0, SeekOrigin.Begin);
            return body;
        }

        private async Task SaveLog(ApiLogModel apiLog, TimeSpan timeSpan)
        {
            string traceId = string.Empty;
            string? jsonRequest = string.IsNullOrEmpty(apiLog.JsonRequest) ? null : apiLog.JsonRequest;
            string? jsonResponse = string.IsNullOrEmpty(apiLog.JsonResponse) ? null : apiLog.JsonResponse;
            string? token = string.IsNullOrEmpty(apiLog.Token) ? null : apiLog.Token;

            var response = JsonConvert.DeserializeObject<ResponseModel>(apiLog.JsonResponse ?? string.Empty);

            if (response == null)
            {
                traceId = _utilities.GenerateId();
            }
            else
            {
                if (string.IsNullOrEmpty(response.TraceId))
                {
                    traceId = _utilities.GenerateId();
                }
                else
                {
                    traceId = response.TraceId;
                }
            }

            try
            {
                await _logRepository.AddApiLog(traceId, timeSpan.TotalSeconds, apiLog.Ip, apiLog.Path, apiLog.StatusCode, jsonRequest, jsonResponse, token);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred saving the 'api log' - {ex.Message}.");
            }
        }
    }
}
