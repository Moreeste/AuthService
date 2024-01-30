using Application.Login.Commands;
using Application.Login.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LoginController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<LoginDTO>> Post(LoginCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
