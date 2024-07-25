using Application.Endpoint.DTOs;

namespace Application.Endpoint.Services
{
    public interface IEndpointService
    {
        Task<RegisterEndpointOutDTO> CreateEndpoint(string idUser, string path);
    }
}
