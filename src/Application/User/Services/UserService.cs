﻿using Application.User.DTOs;
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

        public async Task<PagedList<BasicUserModel>> GetAllUsers(string? idProfile, string? searchTerm, string? sortColumn, string? sortOrder, int page, int pageSize)
        {
            var users = await _userRepository.GetUsers();

            IQueryable<BasicUserModel> usersQuery = users.AsQueryable();

            if (!string.IsNullOrEmpty(idProfile))
            {
                usersQuery = usersQuery.Where(x => x.Profile == idProfile);
            }

            if (!string.IsNullOrEmpty(searchTerm))
            {
                searchTerm = searchTerm.ToUpper();

                usersQuery = usersQuery.Where(x => 
                (x.FirstName != null && x.FirstName.ToUpper().Contains(searchTerm)) || 
                (x.LastName != null && x.LastName.ToUpper().Contains(searchTerm)));
            }
            
            if (!string.IsNullOrEmpty(sortColumn))
            {
                var sortProperty = KeySelector.GetBasicUserModelSortProperty(sortColumn);

                if (sortOrder?.ToLower() == "desc")
                {
                    usersQuery = usersQuery.OrderByDescending(sortProperty);
                }
                else
                {
                    usersQuery = usersQuery.OrderBy(sortProperty);
                }
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
                LastName = user?.LastName,
                Gender = user?.Gender,
                BirthDate = user?.BirthDate.ToString("yyyy-MM-dd"),
                Email = user?.Email,
                PhoneNumber = user?.PhoneNumber
            };

            return result;
        }
    }
}
