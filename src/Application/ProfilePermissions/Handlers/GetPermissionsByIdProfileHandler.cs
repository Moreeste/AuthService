﻿using Application.ProfilePermissions.DTOs;
using Application.ProfilePermissions.Queries;
using Application.ProfilePermissions.Services;
using MediatR;

namespace Application.ProfilePermissions.Handlers
{
    public class GetPermissionsByIdProfileHandler : IRequestHandler<GetPermissionsByIdProfileQuery, IEnumerable<ProfilePermissionsDTO>>
    {
        private IProfilePermissionsService _profilePermissionsService;

        public GetPermissionsByIdProfileHandler(IProfilePermissionsService profilePermissionsService)
        {
            _profilePermissionsService = profilePermissionsService;
        }

        public async Task<IEnumerable<ProfilePermissionsDTO>> Handle(GetPermissionsByIdProfileQuery request, CancellationToken cancellationToken)
        {
            return await _profilePermissionsService.GetPermissionsByIdProfile(request.IdProfile);
        }
    }
}