using Application.UserProperties.DTOs;
using Domain.Exceptions;
using Domain.Model.User;
using Domain.Repository;

namespace Application.UserProperties.Services
{
    public class UserPropertiesService : IUserPropertiesService
    {
        private readonly IUserPropertiesRepository _userPropertiesRepository;
        private readonly IUserRepository _userRepository;
        private readonly IProfileRepository _profileRepository;

        public UserPropertiesService(IUserPropertiesRepository userPropertiesRepository, IUserRepository userRepository, IProfileRepository profileRepository)
        {
            _userPropertiesRepository = userPropertiesRepository;
            _userRepository = userRepository;
            _profileRepository = profileRepository;
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

        public async Task<bool> UpdateUserProfile(string idUser, string idProfile, string updateUser)
        {
            var user = await _userRepository.GetUserById(idUser);

            if (user == null)
            {
                throw new BusinessException("No existe el usuario.");
            }

            var profile = await _profileRepository.GetProfileById(idProfile);

            if (profile == null)
            {
                throw new BusinessException("No existe el perfil.");
            }

            bool userProfileUpdated = await _userPropertiesRepository.UpdateUserProfile(idUser, idProfile, updateUser);

            return userProfileUpdated;
        }

        public async Task<bool> UpdateUserStatus(string idUser, int idStatus, string updateUser)
        {
            var user = await _userRepository.GetUserById(idUser);

            if (user == null)
            {
                throw new BusinessException("No existe el usuario.");
            }

            bool userStatusUpdated = await _userPropertiesRepository.UpdateUserStatus(idUser, idStatus, updateUser);

            return userStatusUpdated;
        }
    }
}
