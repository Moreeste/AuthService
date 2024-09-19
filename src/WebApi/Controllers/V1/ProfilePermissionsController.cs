using Application.ProfilePermissions.Commands;
using Application.ProfilePermissions.DTOs;
using Application.ProfilePermissions.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.V1
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProfilePermissionsController : MainController
    {
        public ProfilePermissionsController(IMediator mediator) : base(mediator)
        {

        }

        [HttpGet]
        public async Task<IEnumerable<ProfilePermissionsDTO>> GetAll()
        {
            var query = new GetProfilePermissionsQuery();
            return await mediator.Send(query);
        }

        [HttpPost]
        public async Task<ActionResult<RegisterPermissionOutDTO>> Post(RegisterPermissionInDTO parameters)
        {
            var command = new RegisterPermissionCommand(GetIdUser());
            return await mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DeletePermissionDTO>> Delete(string id)
        {
            var command = new DeletePermissionCommand(id, GetIdUser());
            return await mediator.Send(command);
        }

        [HttpGet("MyPermissions")]
        public async Task<IEnumerable<ProfilePermissionsDTO>> GetMine()
        {
            var query = new GetPermissionsByIdProfileQuery(GetIdProfile());
            return await mediator.Send(query);
        }
    }
}
