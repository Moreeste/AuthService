using Application.Catalogue.Queries;
using Domain.Model.User;
using Domain.Repository;
using MediatR;

namespace Application.Catalogue.Handlers
{
    public class GetUserStatusHandler : IRequestHandler<GetUserStatusQuery, IEnumerable<UserStatus>>
    {
        private readonly ICatalogueRepository _catalogueRepository;

        public GetUserStatusHandler(ICatalogueRepository catalogueRepository)
        {
            _catalogueRepository = catalogueRepository;
        }

        public async Task<IEnumerable<UserStatus>> Handle(GetUserStatusQuery request, CancellationToken cancellationToken)
        {
            return await _catalogueRepository.GetUserStatus();
        }
    }
}
