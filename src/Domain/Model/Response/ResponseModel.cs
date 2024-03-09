namespace Domain.Model.Response
{
    public class ResponseModel
    {
        public bool Success { get; set; }
        public string? Error { get; set; }
        public string? TraceId { get; set; }
        public object? Data { get; set; }
    }
}
