using Application.UserProperties.DTOs;
using Domain.Exceptions;
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
            var user = await _userRepository.GetUserById(idUser);

            if (user == null)
            {
                throw new SearchException("No existe el usuario.");
            }

            var userProperties = await _userPropertiesRepository.GetUserProperties(idUser);

            if (userProperties == null)
            {
                throw new SearchException("El usuario no cuenta con propiedades.");
            }

            var result = new UserPropertiesDTO()
            {
                Status = userProperties.Status,
                Profile = userProperties.Profile
            };

            return result;
        }
    }
}
