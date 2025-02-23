using Domain.Exceptions;
using Domain.Model.Response;
using Domain.Repository;
using Domain.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Infrastructure.Middleware
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<ErrorHandlingMiddleware> _logger;
        private readonly ILogRepository _logRepository;
        private readonly IUtilities _utilities;

        public ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger, ILogRepository logRepository, IUtilities utilities)
        {
            _logger = logger;
            _logRepository = logRepository;
            _utilities = utilities;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (SqlException ex)
            {
                await HandleExceptionAsync(context, new DataBaseException(ex.Procedure, null, ex.Message));
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            int statusCode;
            string errorMessage;

            switch (exception)
            {
                case SysException:
                    statusCode = StatusCodes.Status500InternalServerError;
                    errorMessage = "An internal error has occurred.";
                    break;
                case DataBaseException:
                    statusCode = StatusCodes.Status500InternalServerError;
                    errorMessage = "A database error has occurred.";
                    break;
                case NotFoundException:
                    statusCode = StatusCodes.Status404NotFound;
                    errorMessage = exception.Message;
                    break;
                case AuthException:
                    statusCode = StatusCodes.Status401Unauthorized;
                    errorMessage = exception.Message;
                    break;
                case BusinessException:
                    statusCode = StatusCodes.Status400BadRequest;
                    errorMessage = exception.Message;
                    break;
                case SearchException:
                    statusCode = StatusCodes.Status404NotFound;
                    errorMessage = exception.Message;
                    break;
                case CustomValidationException:
                    statusCode = StatusCodes.Status400BadRequest;
                    errorMessage = exception.Message;
                    break;
                case JsonRequestException:
                    statusCode = StatusCodes.Status400BadRequest;
                    errorMessage = exception.Message;
                    break;
                default:
                    statusCode = StatusCodes.Status500InternalServerError;
                    errorMessage = "An unknown error has occurred.";
                    break;
            }

            string id = _utilities.GenerateId();

            await SaveLog(id, exception);

            var response = new ErrorResponse(id, errorMessage);
            var jsonResponse = JsonConvert.SerializeObject(response);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;
            
            await context.Response.WriteAsync(jsonResponse);
        }

        private async Task SaveLog(string id, Exception exception)
        {
            string type = exception.GetType().Name;
            string message = exception.Message;
            string? stackTrace = exception.StackTrace;
            string? query = null;
            string? parameters = null;

            if (exception is DataBaseException)
            {
                DataBaseException ex = (DataBaseException)exception;
                query = ex.Query;
                parameters = ex.Parameters;
            }

            try
            {
                await _logRepository.AddErrorLog(id, type, message, stackTrace, query, parameters);
            }
            catch(Exception ex)
            {
                _logger.LogError($"An error occurred saving the 'error log' - {ex.Message}.");
            }
        }
    }
}
