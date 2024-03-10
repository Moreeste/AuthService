using Dapper;
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

        public async Task<bool> AddErrorLog(string traceId, string type, string? message, string? stackTrace)
        {
            string qry = "EXECUTE sp_AddErrorLog @TraceId, @Type, @Message, @StackTrace;";
            var parameters = new
            {
                TraceId = traceId,
                Type = type,
                Message = message,
                StackTrace = stackTrace
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
