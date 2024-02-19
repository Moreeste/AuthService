using Application.User.Queries;
using Application.User.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers.V1
{
    [Authorize]
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
    }
}
