using Application.Profile.DTOs;
using Application.Profile.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.V1
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProfileController : MainController
    {
        public ProfileController(IMediator mediator) : base(mediator)
        {

        }

        [HttpGet]
        public async Task<IEnumerable<ProfileDTO>> GetAll()
        {
            var query = new GetProfilesQuery();
            return await mediator.Send(query);
        }
    }
}
