using Application.Auth.Commands;
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
    }
}
