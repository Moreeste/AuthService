using Application.Login.Commands;
using Application.Login.DTOs;
using Application.Login.Services;
using MediatR;

namespace Application.Login.Handlers
{
    public class LoginHandler : IRequestHandler<LoginCommand, LoginDTO>
    {
        private readonly ILoginService _loginService;

        public LoginHandler(ILoginService loginService)
        {
            _loginService = loginService;
        }

        public async Task<LoginDTO> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            return await _loginService.Login(request.Email, request.Password);
        }
    }
}
