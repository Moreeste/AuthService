using Application.Auth.DTOs;
using MediatR;

namespace Application.Auth.Commands
{
    public sealed record RegisterCommand(
        string Email,
        string PhoneNumber,
        string FirstName,
        string? MiddleName,
        string LastName,
        string? SecondLastName,
        int Gender,
        DateTime BirthDate,
        string Password
        ) : IRequest<RegisterDTO>;
}
