﻿using Application.Auth.Commands;
using Application.Auth.DTOs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.V1
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : MainController
    {
        public AuthController(IMediator mediator) : base(mediator)
        {

        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<ActionResult<LoginDTO>> Login(LoginCommand command)
        {
            return await mediator.Send(command);
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<ActionResult<RegisterDTO>> Post(RegisterCommand command)
        {
            return await mediator.Send(command);
        }

        [AllowAnonymous]
        [HttpPost("RefreshToken")]
        public async Task<ActionResult<LoginDTO>> RefreshToken(RefreshTokenCommand command)
        {
            return await mediator.Send(command);
        }

        [HttpPost("ChangePassword")]
        public async Task<ActionResult<bool>> ChangePassword(ChangePasswordDTO parameters)
        {
            var command = new ChangePasswordCommand(GetIdUser(), parameters.CurrentPassword, parameters.NewPassword);
            return await mediator.Send(command);
        }
    }
}
