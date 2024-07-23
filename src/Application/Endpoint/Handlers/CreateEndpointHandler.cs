using Application.Endpoint.Commands;
using Application.Endpoint.DTOs;
using MediatR;

namespace Application.Endpoint.Handlers
{
    public class CreateEndpointHandler : IRequestHandler<CreateEndpointCommand, CreateEndpointOutDTO>
    {
        public Task<CreateEndpointOutDTO> Handle(CreateEndpointCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
