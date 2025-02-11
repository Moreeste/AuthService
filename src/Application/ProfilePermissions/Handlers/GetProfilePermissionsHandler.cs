using Application.ProfilePermissions.DTOs;
using Application.ProfilePermissions.Queries;
using Application.ProfilePermissions.Services;
using Domain.Model.ProfilePermission;
using Domain.Utilities;
using MediatR;

namespace Application.ProfilePermissions.Handlers
{
    public class GetProfilePermissionsHandler : IRequestHandler<GetProfilePermissionsQuery, PagedList<ProfilePermissionModel>>
    {
        private IProfilePermissionsService _profilePermissionsService;

        public GetProfilePermissionsHandler(IProfilePermissionsService profilePermissionsService)
        {
            _profilePermissionsService = profilePermissionsService;
        }

        public async Task<PagedList<ProfilePermissionModel>> Handle(GetProfilePermissionsQuery request, CancellationToken cancellationToken)
        {
            return await _profilePermissionsService.GetProfilePermissions(request.IdProfile, request.IdEndpoint, request.Active, request.SortColumn, request.SortOrder, Convert.ToInt32(request.Page), Convert.ToInt32(request.PageSize));
        }
    }
}
