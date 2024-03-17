namespace Domain.Model.Response
{
    public class ApiLogModel
    {
        public string? Ip { get; set; }
        public string? Path { get; set; }
        public string? Method { get; set; }
        public string? JsonRequest { get; set; }
        public string? JsonResponse { get; set; }
        public int StatusCode { get; set; }
        public string? Token { get; set; }
    }
}
