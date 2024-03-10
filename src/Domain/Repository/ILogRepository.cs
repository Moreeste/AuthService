namespace Domain.Repository
{
    public interface ILogRepository
    {
        Task<bool> AddErrorLog(string traceId, string type, string? message, string? stackTrace);
    }
}
