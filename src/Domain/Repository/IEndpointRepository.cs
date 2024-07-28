using Domain.Model.Endpoint;

namespace Domain.Repository
{
    public interface IEndpointRepository
    {
        Task<EndpointModel?> GetEndpointById(string idEndpoint);
        Task<IEnumerable<EndpointModel>> GetEndpointByPath(string path);
        Task<bool> RegisterEndpoint(string idEndpoint, string idUser, string path, string method);
    }
}
