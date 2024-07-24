using Application.Endpoint.DTOs;

namespace Application.Endpoint.Services
{
    public interface IEndpointService
    {
        Task<CreateEndpointOutDTO> CreateEndpoint(string idUser, string path);
    }
}
