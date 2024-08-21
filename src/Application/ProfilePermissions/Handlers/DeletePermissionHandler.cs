using Application.ProfilePermissions.Commands;
using Application.ProfilePermissions.DTOs;
using MediatR;

namespace Application.ProfilePermissions.Handlers
{
    public class DeletePermissionHandler : IRequestHandler<DeletePermissionCommand, DeletePermissionDTO>
    {
        public DeletePermissionHandler()
        {
            
        }

        public async Task<DeletePermissionDTO> Handle(DeletePermissionCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
