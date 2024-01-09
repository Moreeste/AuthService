using Application.Modules.Register.Commands;
using Application.Modules.Register.DTOs;
using Application.Modules.Register.Services;
using MediatR;

namespace Application.Modules.Register.Handlers
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
