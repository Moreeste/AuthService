using Application.Endpoint.Queries;
using Application.Endpoint.Services;
using Domain.Model.Endpoint;
using Domain.Utilities;
using MediatR;

namespace Application.Endpoint.Handlers
{
    public class GetEndpointsHandler : IRequestHandler<GetEndpointsQuery, PagedList<EndpointModel>>
    {
        private readonly IEndpointService _endpointService;

        public GetEndpointsHandler(IEndpointService endpointService)
        {
            _endpointService = endpointService;
        }

        public async Task<PagedList<EndpointModel>> Handle(GetEndpointsQuery request, CancellationToken cancellationToken)
        {
            return await _endpointService.GetAllEndpoints(request.Path, request.Method, request.Active, request.SortOrder, Convert.ToInt32(request.Page), Convert.ToInt32(request.PageSize));
        }
    }
}
