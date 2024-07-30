﻿using Application.Endpoint.Commands;
using Application.Endpoint.DTOs;
using Application.Endpoint.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.V1
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EndpointController : MainController
    {
        public EndpointController(IMediator mediator) : base(mediator)
        {

        }

        [HttpPost]
        public async Task<ActionResult<RegisterEndpointOutDTO>> Post(RegisterEndpointInDTO parameters)
        {
            var command = new RegisterEndpointCommand(GetIdUser(), parameters.Path, parameters.Method);
            return await mediator.Send(command);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<EndpointDTO>> GetById(string id)
        {
            var command = new GetEndpointByIdQuery(id);
            return await mediator.Send(command);
        }
    }
}
