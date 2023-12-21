using Application.Modules.User.Commands;
using Application.Modules.User.DTOs;
using Application.Modules.User.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> Get(string id)
        {
            var query = new GetUserByIdQuery(id);
            var item = await _mediator.Send(query);
            return item;
        }

        [HttpPost]
        public async Task<ActionResult<UserDTO>> Post(CreateUserCommand command)
        {
            var item = await _mediator.Send(command);
            return item;
        }
    }
}
