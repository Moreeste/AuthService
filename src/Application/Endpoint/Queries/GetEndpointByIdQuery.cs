using Application.Endpoint.DTOs;
using MediatR;

namespace Application.Endpoint.Queries
{
    public sealed record GetEndpointByIdQuery(string IdEndpoint) : IRequest<EndpointDTO>;
}
