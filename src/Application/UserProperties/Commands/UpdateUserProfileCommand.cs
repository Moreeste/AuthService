using MediatR;

namespace Application.UserProperties.Commands
{
    public sealed record UpdateUserProfileCommand(string IdUser, string IdProfile, string UpdateUser) : IRequest<bool>;
}
