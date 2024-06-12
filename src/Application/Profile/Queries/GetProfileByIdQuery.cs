using Application.Profile.DTOs;
using MediatR;

namespace Application.Profile.Queries
{
    public sealed record GetProfileByIdQuery(string Id) : IRequest<ProfileDTO>;
}
