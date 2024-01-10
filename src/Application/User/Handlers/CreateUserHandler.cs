using Application.User.Commands;
using Application.User.DTOs;
using MediatR;

namespace Application.User.Handlers
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, UserDTO>
    {
        public Task<UserDTO> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
