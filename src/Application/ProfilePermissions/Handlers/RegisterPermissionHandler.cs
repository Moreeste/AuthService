using Application.ProfilePermissions.Commands;
using Application.ProfilePermissions.DTOs;
using Application.ProfilePermissions.Services;
using MediatR;

namespace Application.ProfilePermissions.Handlers
{
    public class RegisterPermissionHandler : IRequestHandler<RegisterPermissionCommand, RegisterPermissionOutDTO>
    {
        private IProfilePermissionsService _profilePermissionsService;

        public RegisterPermissionHandler(IProfilePermissionsService profilePermissionsService)
        {
            _profilePermissionsService = profilePermissionsService;
        }

        public async Task<RegisterPermissionOutDTO> Handle(RegisterPermissionCommand request, CancellationToken cancellationToken)
        {
            return await _profilePermissionsService.RegisterPermission(request.IdProfile, request.IdEndpoint, request.RegistrationUser);
        }
    }
}
