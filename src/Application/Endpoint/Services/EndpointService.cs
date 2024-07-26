using Application.Endpoint.DTOs;
using Domain.Repository;
using Domain.Utilities;

namespace Application.Endpoint.Services
{
    public class EndpointService : IEndpointService
    {
        private readonly IUtilities _utilities;
        private readonly IEndpointRepository _endpointRepository;
        private readonly IUserRepository _userRepository;

        public EndpointService(IUtilities utilities, IEndpointRepository endpointRepository, IUserRepository userRepository)
        {
            _utilities = utilities;
            _endpointRepository = endpointRepository;
            _userRepository = userRepository;
        }

        public async Task<RegisterEndpointOutDTO> RegisterEndpoint(string idUser, string path, string method)
        {
            throw new NotImplementedException();
        }
    }
}
