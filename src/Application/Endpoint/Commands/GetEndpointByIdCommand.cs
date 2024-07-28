using Application.Endpoint.DTOs;
using MediatR;

namespace Application.Endpoint.Commands
{
    public sealed record GetEndpointByIdCommand(string IdEndpoint) : IRequest<EndpointDTO>;
}
