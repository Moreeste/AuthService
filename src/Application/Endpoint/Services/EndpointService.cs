using Application.Endpoint.DTOs;
using Domain.Exceptions;
using Domain.Model.Endpoint;
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

        public async Task<PagedList<EndpointModel>> GetAllEndpoints(string? path, int page, int pageSize)
        {
            var endpoints = await _endpointRepository.GetEndpoints();

            IQueryable<EndpointModel> endpointsQuery = endpoints.AsQueryable();

            if (!string.IsNullOrEmpty(path))
            {
                endpointsQuery = endpointsQuery.Where(x => x.Path != null && x.Path.ToLower().Contains(path.ToLower()));
            }

            var result = PagedList<EndpointModel>.Create(endpointsQuery, page, pageSize);

            return result;
        }

        public async Task<EndpointDTO> GetEndpointById(string idEndpoint)
        {
            var endpoint = await _endpointRepository.GetEndpointById(idEndpoint);

            if (endpoint == null)
            {
                throw new SearchException("No existe el endpoint.");
            }

            return new EndpointDTO
            {
                IdEndpoint = endpoint.IdEndpoint,
                Method = endpoint.Method,
                Path = endpoint.Path,
                Active = endpoint.Active
            };
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
