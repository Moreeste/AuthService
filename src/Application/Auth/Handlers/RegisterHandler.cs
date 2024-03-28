using Application.Auth.Commands;
using Application.Auth.DTOs;
using Application.Auth.Services;
using MediatR;

namespace Application.Auth.Handlers
{
    public class RegisterHandler : IRequestHandler<RegisterCommand, RegisterDTO>
    {
        private readonly IRegisterService _registerService;

        public RegisterHandler(IRegisterService registerService)
        {
            _registerService = registerService;
        }

        public async Task<RegisterDTO> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            return await _registerService.Register(request);
        }
    }
}
