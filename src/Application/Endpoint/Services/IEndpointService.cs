﻿using Application.Endpoint.DTOs;
using Domain.Model.Endpoint;
using Domain.Utilities;

namespace Application.Endpoint.Services
{
    public interface IEndpointService
    {
        Task<PagedList<EndpointModel>> GetAllEndpoints(int page, int pageSize);
        Task<EndpointDTO> GetEndpointById(string idEndpoint);
        Task<RegisterEndpointOutDTO> RegisterEndpoint(string idUser, string path, string method);
    }
}
