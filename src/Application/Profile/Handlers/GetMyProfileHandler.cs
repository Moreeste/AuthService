using Application.Profile.DTOs;
using Application.Profile.Queries;
using Application.Profile.Services;
using MediatR;

namespace Application.Profile.Handlers
{
    public class GetMyProfileHandler : IRequestHandler<GetMyProfileQuery, ProfileDTO>
    {
        private readonly IProfileService _profileService;

        public GetMyProfileHandler(IProfileService profileService)
        {
            _profileService = profileService;
        }

        public async Task<ProfileDTO> Handle(GetMyProfileQuery request, CancellationToken cancellationToken)
        {
            return await _profileService.GetMyProfile(request.IdUser);
        }
    }
}
