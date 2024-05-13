using Application.User.Queries;
using Application.User.Services;
using Domain.Model.User;
using Domain.Utilities;
using MediatR;

namespace Application.User.Handlers
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, PagedList<BasicUserModel>>
    {
        private readonly IUserService _userService;

        public GetAllUsersHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<PagedList<BasicUserModel>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            return await _userService.GetAllUsers(Convert.ToInt32(request.Page), Convert.ToInt32(request.PageSize));
        }
    }
}
