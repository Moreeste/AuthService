using Application.Endpoint.DTOs;

namespace Application.Endpoint.Services
{
    public interface IEndpointService
    {
        Task<EndpointDTO> GetEndpointById(string idEndpoint);
        Task<RegisterEndpointOutDTO> RegisterEndpoint(string idUser, string path, string method);
    }
}
