using Application.Profile.DTOs;
using Application.Profile.Queries;
using Application.Profile.Services;
using MediatR;

namespace Application.Profile.Handlers
{
    public class GetProfilesHandler : IRequestHandler<GetProfilesQuery, IEnumerable<ProfileDTO>>
    {
        private readonly IProfileService _profileService;

        public GetProfilesHandler(IProfileService profileService)
        {
            _profileService = profileService;
        }

        public async Task<IEnumerable<ProfileDTO>> Handle(GetProfilesQuery request, CancellationToken cancellationToken)
        {
            return await _profileService.GetProfiles();
        }
    }
}
