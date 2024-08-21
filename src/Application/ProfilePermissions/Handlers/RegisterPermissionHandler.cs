using Application.ProfilePermissions.Commands;
using Application.ProfilePermissions.DTOs;
using MediatR;

namespace Application.ProfilePermissions.Handlers
{
    public class RegisterPermissionHandler : IRequestHandler<RegisterPermissionCommand, RegisterPermissionOutDTO>
    {
        public RegisterPermissionHandler()
        {
            
        }

        public async Task<RegisterPermissionOutDTO> Handle(RegisterPermissionCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
