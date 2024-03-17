namespace Domain.Repository
{
    public interface ILogRepository
    {
        Task<bool> AddErrorLog(string traceId, string type, string? message, string? stackTrace, string? query, string? qryParameters);
        Task<bool> AddApiLog(string traceId, decimal timeElapsed, string clientIP, string path, int statusCode, bool? success, string? error, string? request, string? response, string? apiResult, string? token);
    }
}
