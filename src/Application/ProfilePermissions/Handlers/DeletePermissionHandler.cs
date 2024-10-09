using Application.ProfilePermissions.Commands;
using Application.ProfilePermissions.DTOs;
using Application.ProfilePermissions.Services;
using MediatR;

namespace Application.ProfilePermissions.Handlers
{
    public class DeletePermissionHandler : IRequestHandler<DeletePermissionCommand, DeletePermissionDTO>
    {
        private IProfilePermissionsService _profilePermissionsService;

        public DeletePermissionHandler(IProfilePermissionsService profilePermissionsService)
        {
            _profilePermissionsService = profilePermissionsService;
        }

        public async Task<DeletePermissionDTO> Handle(DeletePermissionCommand request, CancellationToken cancellationToken)
        {
            return await _profilePermissionsService.DeletePermission(request.IdPermission, request.UpdaterUser);
        }
    }
}
