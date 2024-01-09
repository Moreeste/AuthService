using Application.Modules.Register.Commands;
using Application.Modules.Register.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RegisterController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<RegisterDTO>> Post(RegisterCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
