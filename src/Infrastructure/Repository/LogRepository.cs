﻿using Dapper;
using Domain.Exceptions;
using Domain.Model.Response;
using Domain.Repository;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class LogRepository : ILogRepository
    {
        private readonly AuthServiceContext _authServiceContext;

        public LogRepository(AuthServiceContext authServiceContext)
        {
            _authServiceContext = authServiceContext;
        }

        public async Task<bool> AddErrorLog(string traceId, string type, string? message, string? stackTrace, string? query, string? qryParameters)
        {
            string qry = "EXECUTE sp_AddErrorLog @TraceId, @Type, @Message, @StackTrace, @Query, @QryParameters;";
            var parameters = new
            {
                TraceId = traceId,
                Type = type,
                Message = message,
                StackTrace = stackTrace,
                Query = query,
                QryParameters = qryParameters
            };
            
            var result = await _authServiceContext.Database.GetDbConnection().QueryFirstOrDefaultAsync<DbResponse>(qry, parameters);

            if (result == null)
            {
                throw new DataBaseException(qry, parameters);
            }

            if (!result.Success)
            {
                throw new DataBaseException(qry, parameters, result.ErrorMessage);
            }

            return true;
        }

        public async Task<bool> AddApiLog(string traceId, double timeElapsed, string? clientIP, string? path, int statusCode, string? request, string? response, string? token)
        {
            string qry = "EXECUTE sp_AddApiLog @TraceId, @TimeElapsed, @ClientIP, @Path, @StatusCode, @Request, @Response, @Token;";
            var parameters = new
            {
                TraceId = traceId,
                TimeElapsed = timeElapsed,
                ClientIP = clientIP,
                Path = path,
                StatusCode = statusCode,
                Request = request,
                Response = response,
                Token = token
            };

            var result = await _authServiceContext.Database.GetDbConnection().QueryFirstOrDefaultAsync<DbResponse>(qry, parameters);

            if (result == null)
            {
                throw new DataBaseException(qry, parameters);
            }

            if (!result.Success)
            {
                throw new DataBaseException(qry, parameters, result.ErrorMessage);
            }

            return true;
        }
    }
}
