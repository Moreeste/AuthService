namespace Domain.Model.Endpoint
{
    public class EndpointModel
    {
        public string? IdEndpoint { get; set; }
        public string? Method { get; set; }
        public string? Path { get; set; }
        public bool IsPublic { get; set; }
        public bool IsForEveryone { get; set; }
        public bool Active { get; set; }
    }
}
