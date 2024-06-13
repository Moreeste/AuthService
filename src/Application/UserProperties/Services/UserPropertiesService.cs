using Application.UserProperties.DTOs;
using Domain.Repository;

namespace Application.UserProperties.Services
{
    public class UserPropertiesService : IUserPropertiesService
    {
        private readonly IUserPropertiesRepository _userPropertiesRepository;
        private readonly IUserRepository _userRepository;

        public UserPropertiesService(IUserPropertiesRepository userPropertiesRepository, IUserRepository userRepository)
        {
            _userPropertiesRepository = userPropertiesRepository;
            _userRepository = userRepository;

        }

        public async Task<UserPropertiesDTO> GetUserProperties(string idUser)
        {
            throw new NotImplementedException();
        }
    }
}
