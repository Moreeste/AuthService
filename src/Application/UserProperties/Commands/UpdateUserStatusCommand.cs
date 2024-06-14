using MediatR;

namespace Application.UserProperties.Commands
{
    public sealed record UpdateUserStatusCommand(string IdUser, int IdStatus, string UpdateUser) : IRequest<bool>;
}
