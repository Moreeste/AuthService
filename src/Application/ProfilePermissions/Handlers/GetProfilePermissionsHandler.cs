using Application.ProfilePermissions.DTOs;
using Application.ProfilePermissions.Queries;
using MediatR;

namespace Application.ProfilePermissions.Handlers
{
    public class GetProfilePermissionsHandler : IRequestHandler<GetProfilePermissionsQuery, IEnumerable<ProfilePermissionsDTO>>
    {
        public GetProfilePermissionsHandler()
        {
            
        }

        public async Task<IEnumerable<ProfilePermissionsDTO>> Handle(GetProfilePermissionsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
