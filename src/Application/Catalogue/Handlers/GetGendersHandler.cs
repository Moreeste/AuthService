using Application.Catalogue.Queries;
using Domain.Model.User;
using Domain.Repository;
using MediatR;

namespace Application.Catalogue.Handlers
{
    public class GetGendersHandler : IRequestHandler<GetGendersQuery, IEnumerable<Gender>>
    {
        private readonly ICatalogueRepository _catalogueRepository;

        public GetGendersHandler(ICatalogueRepository catalogueRepository)
        {
            _catalogueRepository = catalogueRepository;
        }

        public async Task<IEnumerable<Gender>> Handle(GetGendersQuery request, CancellationToken cancellationToken)
        {
            return await _catalogueRepository.GetGenders();
        }
    }
}
