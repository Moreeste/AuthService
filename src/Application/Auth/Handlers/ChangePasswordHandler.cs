using Application.Auth.Commands;
using Application.Auth.Services;
using MediatR;

namespace Application.Auth.Handlers
{
    public class ChangePasswordHandler : IRequestHandler<ChangePasswordCommand, bool>
    {
        private readonly IChangePasswordService _changePasswordService;

        public ChangePasswordHandler(IChangePasswordService changePasswordService)
        {
            _changePasswordService = changePasswordService;
        }

        public async Task<bool> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            return await _changePasswordService.ChangePassword(request.IdUser, request.CurrentPassword, request.NewPassword);
        }
    }
}
