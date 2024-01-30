using Application.Auth.Commands;
using Application.Auth.DTOs;
using Application.Auth.Services;
using MediatR;

namespace Application.Auth.Handlers
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
