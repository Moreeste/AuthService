using Application.Endpoint.DTOs;
using MediatR;

namespace Application.Endpoint.Commands
{
    public sealed record RegisterEndpointCommand(string IdUser, string Path, string Method, bool IsPublic, bool IsForEveryone) : IRequest<RegisterEndpointOutDTO>;
}
