using Application.Profile.Commands;
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

        [HttpGet("{id}")]
        public async Task<ProfileDTO> GetById(string id)
        {
            var query = new GetProfileByIdQuery(id);
            return await mediator.Send(query);
        }

        [HttpPost]
        public async Task<ActionResult<CreateProfileOutDTO>> Post(CreateProfileInDTO parameters)
        {
            var command = new CreateProfileCommand(parameters.Description, GetIdUser());
            return await mediator.Send(command);
        }
    }
}
