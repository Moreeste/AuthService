using Application.Register.DTOs;
using MediatR;

namespace Application.Register.Commands
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
