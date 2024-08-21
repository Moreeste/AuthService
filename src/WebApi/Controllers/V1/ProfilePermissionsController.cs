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
    }
}
