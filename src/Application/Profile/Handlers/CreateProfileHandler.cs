using Application.Profile.Commands;
using Application.Profile.DTOs;
using Application.Profile.Services;
using MediatR;

namespace Application.Profile.Handlers
{
    public class CreateProfileHandler : IRequestHandler<CreateProfileCommand, CreateProfileOutDTO>
    {
        private readonly IProfileService _profileService;

        public CreateProfileHandler(IProfileService profileService)
        {
            _profileService = profileService;
        }

        public async Task<CreateProfileOutDTO> Handle(CreateProfileCommand request, CancellationToken cancellationToken)
        {
            return await _profileService.CreateProfile(request.Description?? string.Empty, request.RegistrationUser);
        }
    }
}
