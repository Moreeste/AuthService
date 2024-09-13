namespace Application.Endpoint.DTOs
{
    public sealed record RegisterEndpointInDTO(string Path, string Method, bool IsPublic);
}
