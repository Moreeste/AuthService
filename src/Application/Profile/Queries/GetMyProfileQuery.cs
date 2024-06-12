using Application.Profile.DTOs;
using MediatR;

namespace Application.Profile.Queries
{
    public sealed record GetMyProfileQuery(string IdUser) : IRequest<ProfileDTO>;
}
