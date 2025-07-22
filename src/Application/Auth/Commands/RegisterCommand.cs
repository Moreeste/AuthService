using Application.Auth.DTOs;
using MediatR;

namespace Application.Auth.Commands
{
    public sealed record RegisterCommand(
        string Email,
        string PhoneNumber,
        string FirstName,
        string LastName,
        int Gender,
        string BirthDate,
        string Password
        ) : IRequest<RegisterDTO>;
}
