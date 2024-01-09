using Application.Modules.Register.DTOs;
using MediatR;

namespace Application.Modules.Register.Commands
{
    public sealed record RegisterCommand(
        string Email, 
        string PhoneNumber,
        string FirstName,
        string MiddleName, 
        string LastName, 
        string SecondLastName,
        int Gender, 
        DateTime BirthDate, 
        string Password
        ) : IRequest<RegisterDTO>;
}
