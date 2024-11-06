using Application.ProfilePermissions.Commands;
using Application.ProfilePermissions.DTOs;
using Application.ProfilePermissions.Queries;
using Domain.Utilities;
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
        public async Task<PagedList<ProfilePermissionsDTO>> GetAll(
            [FromQuery] string? idProfile,
            [FromQuery] string? idEndpoint,
            [FromQuery] string? active,
            [FromQuery] string? sortColumn,
            [FromQuery] string? sortOrder,
            [FromQuery] string page = "1",
            [FromQuery] string pageSize = "10")
        {
            var query = new GetProfilePermissionsQuery(idProfile, idEndpoint, active, sortColumn, sortOrder, page, pageSize);
            return await mediator.Send(query);
        }

        [HttpPost]
        public async Task<ActionResult<RegisterPermissionOutDTO>> Post(RegisterPermissionInDTO parameters)
        {
            var command = new RegisterPermissionCommand(parameters.IdProfile, parameters.IdEndpoint, GetIdUser());
            return await mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DeletePermissionDTO>> Delete(string id)
        {
            var command = new DeletePermissionCommand(id, GetIdUser());
            return await mediator.Send(command);
        }

        [HttpGet("MyPermissions")]
        public async Task<IEnumerable<PermissionsByProfileDTO>> GetMine()
        {
            var query = new GetPermissionsByIdProfileQuery(GetIdProfile());
            return await mediator.Send(query);
        }
    }
}
