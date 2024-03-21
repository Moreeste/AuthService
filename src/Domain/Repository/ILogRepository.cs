namespace Domain.Repository
{
    public interface ILogRepository
    {
        Task<bool> AddErrorLog(string traceId, string type, string? message, string? stackTrace, string? query, string? qryParameters);
        Task<bool> AddApiLog(string traceId, double timeElapsed, string? clientIP, string? path, int statusCode, string? request, string? response, string? token);
    }
}
