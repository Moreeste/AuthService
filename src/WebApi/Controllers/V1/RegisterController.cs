using Application.Register.Commands;
using Application.Register.DTOs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.V1
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RegisterController : MainController
    {
        public RegisterController(IMediator mediator) : base(mediator)
        {

        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<RegisterDTO>> Post(RegisterCommand command)
        {
            return await mediator.Send(command);
        }
    }
}
