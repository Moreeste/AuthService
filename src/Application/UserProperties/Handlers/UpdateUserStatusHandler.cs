using Application.UserProperties.Commands;
using Application.UserProperties.Services;
using MediatR;

namespace Application.UserProperties.Handlers
{
    public class UpdateUserStatusHandler : IRequestHandler<UpdateUserStatusCommand, bool>
    {
        private readonly IUserPropertiesService _userPropertiesService;

        public UpdateUserStatusHandler(IUserPropertiesService userPropertiesService)
        {
            _userPropertiesService = userPropertiesService;
        }

        public async Task<bool> Handle(UpdateUserStatusCommand request, CancellationToken cancellationToken)
        {
            return await _userPropertiesService.UpdateUserStatus(request.IdUser, request.IdStatus, request.UpdateUser);
        }
    }
}
