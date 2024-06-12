using Domain.Model.User;
using MediatR;

namespace Application.Catalogue.Queries
{
    public sealed record GetUserStatusQuery : IRequest<IEnumerable<UserStatus>>;
}
