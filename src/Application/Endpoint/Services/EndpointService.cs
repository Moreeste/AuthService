using Application.Endpoint.DTOs;
using Domain.Exceptions;
using Domain.Repository;
using Domain.Utilities;

namespace Application.Endpoint.Services
{
    public class EndpointService : IEndpointService
    {
        private readonly IUtilities _utilities;
        private readonly IEndpointRepository _endpointRepository;

        public EndpointService(IUtilities utilities, IEndpointRepository endpointRepository)
        {
            _utilities = utilities;
            _endpointRepository = endpointRepository;
        }

        public async Task<RegisterEndpointOutDTO> RegisterEndpoint(string idUser, string path, string method)
        {
            var endpointList = await _endpointRepository.GetEndpointByPath(path);

            if (endpointList != null && endpointList.Count() > 0)
            {
                var existeEndpoint = endpointList.Any(x => x.Method == method.ToUpper());

                if (existeEndpoint)
                {
                    throw new BusinessException($"Ya existe el {method.ToUpper()} {path}.");
                }
            }

            var idEndpoint = _utilities.GenerateId();

            await _endpointRepository.RegisterEndpoint(idEndpoint, idUser, path.ToLower(), method.ToUpper());

            return new RegisterEndpointOutDTO
            {
                IdEndpoint = idEndpoint
            };
        }
    }
}
