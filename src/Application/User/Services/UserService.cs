using Application.User.DTOs;
using Domain.Exceptions;
using Domain.Repository;

namespace Application.User.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsers()
        {
            var userList = await _userRepository.GetAllUsers();

            IEnumerable<UserDTO> result = userList.Select(user => new UserDTO
            {
                IdUser = user?.IdUser,
                FirstName = user?.FirstName,
                MiddleName = user?.MiddleName,
                LastName = user?.LastName,
                SecondLastName = user?.SecondLastName,
                Gender = user?.Gender,
                BirthDate = user?.BirthDate.ToString("yyyy-MM-dd"),
                Email = user?.Email,
                PhoneNumber = user?.PhoneNumber,
                Profile = user?.Profile
            });

            return result;
        }

        public async Task<UserDTO> GetUserById(string id)
        {
            var user = await _userRepository.GetUserById(id);

            if (user == null)
            {
                throw new SearchException("No existe el usuario.");
            }

            var result = new UserDTO()
            {
                IdUser = user?.IdUser,
                FirstName = user?.FirstName,
                MiddleName = user?.MiddleName,
                LastName = user?.LastName,
                SecondLastName = user?.SecondLastName,
                Gender = user?.Gender,
                BirthDate = user?.BirthDate.ToString("yyyy-MM-dd"),
                Email = user?.Email,
                PhoneNumber = user?.PhoneNumber,
                Profile = user?.Profile
            };

            return result;
        }
    }
}
