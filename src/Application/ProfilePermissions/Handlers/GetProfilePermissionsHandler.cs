using Application.ProfilePermissions.DTOs;
using Application.ProfilePermissions.Queries;
using Application.ProfilePermissions.Services;
using MediatR;

namespace Application.ProfilePermissions.Handlers
{
    public class GetProfilePermissionsHandler : IRequestHandler<GetProfilePermissionsQuery, IEnumerable<ProfilePermissionsDTO>>
    {
        private IProfilePermissionsService _profilePermissionsService;

        public GetProfilePermissionsHandler(IProfilePermissionsService profilePermissionsService)
        {
            _profilePermissionsService = profilePermissionsService;
        }

        public async Task<IEnumerable<ProfilePermissionsDTO>> Handle(GetProfilePermissionsQuery request, CancellationToken cancellationToken)
        {
            return await _profilePermissionsService.GetProfilePermissions();
        }
    }
}
