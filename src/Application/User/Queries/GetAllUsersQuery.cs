using Domain.Model.User;
using Domain.Utilities;
using MediatR;

namespace Application.User.Queries
{
    public sealed record GetAllUsersQuery(string Page, string PageSize) : IRequest<PagedList<BasicUserModel>>;
}
