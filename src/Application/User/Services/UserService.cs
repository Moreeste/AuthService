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

        public async Task<PagedList<BasicUserModel>> GetAllUsers(string? searchTerm, string? sortColumn, string? sortOrder, int page, int pageSize)
        {
            var users = await _userRepository.GetUsers();

            IQueryable<BasicUserModel> usersQuery = users.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                searchTerm = searchTerm.ToUpper();

                usersQuery = usersQuery.Where(x => 
                (x.FirstName != null && x.FirstName.ToUpper().Contains(searchTerm)) || 
                (x.MiddleName != null && x.MiddleName.ToUpper().Contains(searchTerm)) ||
                (x.LastName != null && x.LastName.ToUpper().Contains(searchTerm)) ||
                (x.SecondLastName != null && x.SecondLastName.ToUpper().Contains(searchTerm)));
            }

            var result = PagedList<BasicUserModel>.Create(usersQuery, page, pageSize);

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
