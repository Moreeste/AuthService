using Application.User.DTOs;
using Domain.Exceptions;
using Domain.Model.User;
using Domain.Repository;
using Domain.Utilities;

namespace Application.User.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<PagedList<BasicUserModel>> GetAllUsers(int page, int pageSize)
        {
            var users = await _userRepository.GetUsers();

            var result = PagedList<BasicUserModel>.Create(users, page, pageSize);

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
                PhoneNumber = user?.PhoneNumber
            };

            return result;
        }
    }
}
