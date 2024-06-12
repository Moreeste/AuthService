using Domain.Model.User;
using MediatR;

namespace Application.Catalogue.Queries
{
    public sealed record GetGendersQuery : IRequest<IEnumerable<Gender>>;
}
