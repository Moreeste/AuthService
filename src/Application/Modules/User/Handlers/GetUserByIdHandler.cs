using Application.Modules.User.DTOs;
using Application.Modules.User.Queries;
using Application.Modules.User.Services;
using MediatR;

namespace Application.Modules.User.Handlers
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, UserDTO>
    {
        private readonly IUserService _userService;
        
        public GetUserByIdHandler(IUserService userService)
        {
            _userService = userService;
        }
        
        public async Task<UserDTO> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return await _userService.GetUserById(request.Id);
        }
    }
}
