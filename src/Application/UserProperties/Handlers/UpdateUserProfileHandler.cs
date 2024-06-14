using Application.UserProperties.Commands;
using Application.UserProperties.Services;
using MediatR;

namespace Application.UserProperties.Handlers
{
    public class UpdateUserProfileHandler : IRequestHandler<UpdateUserProfileCommand, bool>
    {
        private readonly IUserPropertiesService _userPropertiesService;

        public UpdateUserProfileHandler(IUserPropertiesService userPropertiesService)
        {
            _userPropertiesService = userPropertiesService;
        }

        public async Task<bool> Handle(UpdateUserProfileCommand request, CancellationToken cancellationToken)
        {
            return await _userPropertiesService.UpdateUserProfile(request.IdUser, request.IdProfile, request.UpdateUser);
        }
    }
}
