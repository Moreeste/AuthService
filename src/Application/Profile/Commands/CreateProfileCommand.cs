using Application.Profile.DTOs;
using MediatR;

namespace Application.Profile.Commands
{
    public sealed record CreateProfileCommand(string? Description, string RegistrationUser) : IRequest<CreateProfileOutDTO>;
}
