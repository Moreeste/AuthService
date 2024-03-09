namespace Domain.Model.Response
{
    public class ResponseModel
    {
        public bool Success { get; set; }
        public string? TraceId { get; set; }
        public string? Error { get; set; }
        public object? Result { get; set; }
    }
}
