using Application.Modules.User.Commands;
using Application.Modules.User.DTOs;
using MediatR;

namespace Application.Modules.User.Handlers
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, UserDTO>
    {
        public Task<UserDTO> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
