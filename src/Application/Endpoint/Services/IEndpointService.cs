using Application.Endpoint.DTOs;
using Domain.Model.Endpoint;
using Domain.Utilities;

namespace Application.Endpoint.Services
{
    public interface IEndpointService
    {
        Task<PagedList<EndpointModel>> GetAllEndpoints(string? path, string? method, string? IsPublic, string? active, string? sortOrder, int page, int pageSize);
        Task<EndpointDTO> GetEndpointById(string idEndpoint);
        Task<RegisterEndpointOutDTO> RegisterEndpoint(string idUser, string path, string method, bool isPublic);
    }
}
