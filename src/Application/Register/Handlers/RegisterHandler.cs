using Application.Register.Commands;
using Application.Register.DTOs;
using Application.Register.Services;
using MediatR;

namespace Application.Register.Handlers
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
