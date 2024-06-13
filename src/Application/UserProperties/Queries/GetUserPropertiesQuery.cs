using Application.UserProperties.DTOs;
using MediatR;

namespace Application.UserProperties.Queries
{
    public sealed record GetUserPropertiesQuery(string IdUser) : IRequest<UserPropertiesDTO>;
}
