using Application.UserProperties.DTOs;
using Application.UserProperties.Queries;
using Application.UserProperties.Services;
using MediatR;

namespace Application.UserProperties.Handlers
{
    public class GetUserPropertiesHandler : IRequestHandler<GetUserPropertiesQuery, UserPropertiesDTO>
    {
        private readonly IUserPropertiesService _userPropertiesService;

        public GetUserPropertiesHandler(IUserPropertiesService userPropertiesService)
        {
            _userPropertiesService = userPropertiesService;
        }

        public async Task<UserPropertiesDTO> Handle(GetUserPropertiesQuery request, CancellationToken cancellationToken)
        {
            return await _userPropertiesService.GetUserProperties(request.IdUser);
        }
    }
}
