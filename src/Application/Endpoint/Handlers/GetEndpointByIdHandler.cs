using Application.Endpoint.Commands;
using Application.Endpoint.DTOs;
using Application.Endpoint.Services;
using MediatR;

namespace Application.Endpoint.Handlers
{
    public class GetEndpointByIdHandler : IRequestHandler<GetEndpointByIdCommand, EndpointDTO>
    {
        private readonly IEndpointService _endpointService;

        public GetEndpointByIdHandler(IEndpointService endpointService)
        {
            _endpointService = endpointService;
        }

        public async Task<EndpointDTO> Handle(GetEndpointByIdCommand request, CancellationToken cancellationToken)
        {
            return await _endpointService.GetEndpointById(request.IdEndpoint);
        }
    }
}
