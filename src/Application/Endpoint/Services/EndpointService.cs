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

        public async Task<PagedList<EndpointModel>> GetAllEndpoints(string? path, string? method, string? isPublic, string? isForEveryone, string? active, string? sortOrder, int page, int pageSize)
        {
            var endpoints = await _endpointRepository.GetEndpoints();

            IQueryable<EndpointModel> endpointsQuery = endpoints.AsQueryable();

            if (!string.IsNullOrEmpty(path))
            {
                endpointsQuery = endpointsQuery.Where(x => x.Path != null && x.Path.ToLower().Contains(path.ToLower()));
            }

            if (!string.IsNullOrEmpty(method))
            {
                endpointsQuery = endpointsQuery.Where(x => x.Method != null && x.Method.ToUpper().Contains(method.ToUpper()));
            }

            if (!string.IsNullOrEmpty(isPublic))
            {
                if (isPublic == "1")
                {
                    endpointsQuery = endpointsQuery.Where(x => x.IsPublic == true);
                }
                else if (isPublic == "0")
                {
                    endpointsQuery = endpointsQuery.Where(x => x.IsPublic == false);
                }
            }

            if (!string.IsNullOrEmpty(isForEveryone))
            {
                if (isForEveryone == "1")
                {
                    endpointsQuery = endpointsQuery.Where(x => x.IsForEveryone == true);
                }
                else if (isForEveryone == "0")
                {
                    endpointsQuery = endpointsQuery.Where(x => x.IsForEveryone == false);
                }
            }

            if (!string.IsNullOrEmpty(active))
            {
                if (active == "1")
                {
                    endpointsQuery = endpointsQuery.Where(x => x.Active == true);
                }
                else if (active == "0")
                {
                    endpointsQuery = endpointsQuery.Where(x => x.Active == false);
                }
            }

            if (sortOrder?.ToLower() == "desc")
            {
                endpointsQuery = endpointsQuery.OrderByDescending(x => x.Path);
            }
            else
            {
                endpointsQuery = endpointsQuery.OrderBy(x => x.Path);
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
                IsPublic = endpoint.IsPublic,
                IsForEveryone = endpoint.IsForEveryone,
                Active = endpoint.Active
            };
        }

        public async Task<RegisterEndpointOutDTO> RegisterEndpoint(string idUser, string path, string method, bool isPublic, bool isForEveryone)
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

            await _endpointRepository.RegisterEndpoint(idEndpoint, idUser, path.ToLower(), method.ToUpper(), isPublic, isForEveryone);

            return new RegisterEndpointOutDTO
            {
                IdEndpoint = idEndpoint
            };
        }
    }
}
