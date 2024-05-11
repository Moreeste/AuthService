using Application.User.Queries;
using Application.User.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Domain.Utilities;

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
        public async Task<PagedList<UserDTO>> GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var query = new GetAllUsersQuery(page, pageSize);
            return await mediator.Send(query);
        }

        [HttpGet("MyUser")]
        public async Task<ActionResult<UserDTO>> GetMine()
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
