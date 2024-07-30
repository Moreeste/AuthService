using Domain.Model.Endpoint;
using Domain.Utilities;
using MediatR;

namespace Application.Endpoint.Queries
{
    public sealed record GetEndpointsQuery : IRequest<PagedList<EndpointModel>>;
}
