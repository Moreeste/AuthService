using Application.Modules.User.DTOs;
using Application.Modules.User.Queries;
using Domain.Repository;
using MediatR;

namespace Application.Modules.User.Handlers
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, UserDTO>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDTO> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var consulta = await _userRepository.GetUserById(request.Id);

            var result = new UserDTO()
            {
                FirstName = consulta.FirstName
            };

            return result;
        }
    }
}
