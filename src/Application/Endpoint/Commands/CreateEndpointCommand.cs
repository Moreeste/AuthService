﻿using Application.Endpoint.DTOs;
using MediatR;

namespace Application.Endpoint.Commands
{
    public sealed record CreateEndpointCommand(string IdUser, string Path) : IRequest<CreateEndpointOutDTO>;
}
