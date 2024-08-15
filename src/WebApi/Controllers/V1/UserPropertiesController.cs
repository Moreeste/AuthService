using Application.UserProperties.Commands;
using Application.UserProperties.DTOs;
using Application.UserProperties.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.V1
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserPropertiesController : MainController
    {
        public UserPropertiesController(IMediator mediator) : base(mediator)
        {

        }

        [HttpGet("{id}")]
        public async Task<UserPropertiesDTO> GetMine(string id)
        {
            var query = new GetUserPropertiesQuery(id);
            return await mediator.Send(query);
        }

        [HttpGet("MyProperties")]
        public async Task<UserPropertiesDTO> GetMine()
        {
            var query = new GetUserPropertiesQuery(GetIdUser());
            return await mediator.Send(query);
        }
        
        [HttpPut("Profile")]
        public async Task<bool> PutProfile(UpdateUserProfileDTO parameters)
        {
            var command = new UpdateUserProfileCommand(parameters.IdUser, parameters.IdProfile, GetIdUser());
            return await mediator.Send(command);
        }

        [HttpPut("Status")]
        public async Task<bool> PutStatus(UpdateUserStatusDTO parameters)
        {
            var command = new UpdateUserStatusCommand(parameters.IdUser, parameters.IdStatus, GetIdUser());
            return await mediator.Send(command);
        }
    }
}
