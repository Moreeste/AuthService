using Domain.Model.Endpoint;
using Domain.Utilities;
using MediatR;

namespace Application.Endpoint.Queries
{
    public sealed record GetEndpointsQuery(string Page, string PageSize) : IRequest<PagedList<EndpointModel>>;
}
