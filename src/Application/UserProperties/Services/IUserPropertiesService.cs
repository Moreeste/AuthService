using Application.UserProperties.DTOs;

namespace Application.UserProperties.Services
{
    public interface IUserPropertiesService
    {
        Task<UserPropertiesDTO> GetUserProperties(string idUser);
    }
}
