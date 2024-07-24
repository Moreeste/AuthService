﻿using Application.Endpoint.Commands;
using Application.Endpoint.DTOs;
using Application.Endpoint.Services;
using MediatR;

namespace Application.Endpoint.Handlers
{
    public class CreateEndpointHandler : IRequestHandler<CreateEndpointCommand, CreateEndpointOutDTO>
    {
        private readonly IEndpointService _endpointService;

        public CreateEndpointHandler(IEndpointService endpointService)
        {
            _endpointService = endpointService;
        }

        public async Task<CreateEndpointOutDTO> Handle(CreateEndpointCommand request, CancellationToken cancellationToken)
        {
            return await _endpointService.CreateEndpoint(request.IdUser, request.Path);
        }
    }
}