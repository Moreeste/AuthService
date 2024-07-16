using MediatR;

namespace Application.Auth.Commands
{
    public sealed record ChangePasswordCommand(string IdUser, string CurrentPassword, string NewPassword) : IRequest<bool>;
}
