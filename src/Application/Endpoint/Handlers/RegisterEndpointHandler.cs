using Application.Endpoint.Commands;
using Application.Endpoint.DTOs;
using Application.Endpoint.Services;
using MediatR;

namespace Application.Endpoint.Handlers
{
    public class RegisterEndpointHandler : IRequestHandler<RegisterEndpointCommand, RegisterEndpointOutDTO>
    {
        private readonly IEndpointService _endpointService;

        public RegisterEndpointHandler(IEndpointService endpointService)
        {
            _endpointService = endpointService;
        }

        public async Task<RegisterEndpointOutDTO> Handle(RegisterEndpointCommand request, CancellationToken cancellationToken)
        {
            return await _endpointService.RegisterEndpoint(request.IdUser, request.Path, request.Method, request.IsPublic, request.IsForEveryone);
        }
    }
}
