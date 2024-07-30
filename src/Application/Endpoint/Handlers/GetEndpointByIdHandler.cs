using Application.Endpoint.DTOs;
using Application.Endpoint.Queries;
using Application.Endpoint.Services;
using MediatR;

namespace Application.Endpoint.Handlers
{
    public class GetEndpointByIdHandler : IRequestHandler<GetEndpointByIdQuery, EndpointDTO>
    {
        private readonly IEndpointService _endpointService;

        public GetEndpointByIdHandler(IEndpointService endpointService)
        {
            _endpointService = endpointService;
        }

        public async Task<EndpointDTO> Handle(GetEndpointByIdQuery request, CancellationToken cancellationToken)
        {
            return await _endpointService.GetEndpointById(request.IdEndpoint);
        }
    }
}
