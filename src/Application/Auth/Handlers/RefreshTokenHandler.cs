using Application.Auth.Commands;
using Application.Auth.DTOs;
using Application.Auth.Services;
using MediatR;

namespace Application.Auth.Handlers
{
    public class RefreshTokenHandler : IRequestHandler<RefreshTokenCommand, LoginDTO>
    {
        private readonly ILoginService _loginService;

        public RefreshTokenHandler(ILoginService loginService)
        {
            _loginService = loginService;
        }

        public async Task<LoginDTO> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            return await _loginService.RefreshToken(request.ExpiredToken, request.RefreshToken);
        }
    }
}
