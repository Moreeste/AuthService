using Application.Profile.DTOs;
using Application.Profile.Queries;
using Application.Profile.Services;
using MediatR;

namespace Application.Profile.Handlers
{
    public class GetProfileByIdHandler : IRequestHandler<GetProfileByIdQuery, ProfileDTO>
    {
        private readonly IProfileService _profileService;

        public GetProfileByIdHandler(IProfileService profileService)
        {
            _profileService = profileService;
        }

        public async Task<ProfileDTO> Handle(GetProfileByIdQuery request, CancellationToken cancellationToken)
        {
            return await _profileService.GetProfileById(request.Id);
        }
    }
}
