using Application.UserProperties.DTOs;

namespace Application.UserProperties.Services
{
    public interface IUserPropertiesService
    {
        Task<UserPropertiesDTO> GetUserProperties(string idUser);
        Task<bool> UpdateUserProfile(string idUser, string idProfile, string updateUser);
        Task<bool> UpdateUserStatus(string idUser, int idStatus, string updateUser);
    }
}
