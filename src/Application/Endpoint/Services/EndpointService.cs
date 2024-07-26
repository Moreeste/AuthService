using Application.Endpoint.DTOs;
using Domain.Repository;

namespace Application.Endpoint.Services
{
    public class EndpointService : IEndpointService
    {
        private readonly IEndpointRepository _endpointRepository;

        public EndpointService(IEndpointRepository endpointRepository)
        {
            _endpointRepository = endpointRepository;
        }

        public async Task<RegisterEndpointOutDTO> RegisterEndpoint(string idUser, string path, string method)
        {
            throw new NotImplementedException();
        }
    }
}
