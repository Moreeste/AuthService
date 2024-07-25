using Application.Endpoint.DTOs;

namespace Application.Endpoint.Services
{
    public interface IEndpointService
    {
        Task<RegisterEndpointOutDTO> RegisterEndpoint(string idUser, string path);
    }
}
