﻿using Application.User.Queries;
using Application.User.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers.V1
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : MainController
    {
        public UserController(IMediator mediator) : base(mediator)
        {

        }

        [HttpGet]
        public async Task<ActionResult<UserDTO>> Get()
        {
            var query = new GetUserByIdQuery(GetIdUser());
            return await mediator.Send(query);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetById(string id)
        {
            var query = new GetUserByIdQuery(id);
            return await mediator.Send(query);
        }
    }
}
