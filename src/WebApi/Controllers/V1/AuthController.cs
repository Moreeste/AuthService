using Application.Auth.Commands;
using Application.Auth.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<LoginDTO>> Login(LoginCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
