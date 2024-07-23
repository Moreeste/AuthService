using Application.Endpoint.Commands;
using Application.Endpoint.DTOs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.V1
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EndpointController : MainController
    {
        public EndpointController(IMediator mediator) : base(mediator)
        {

        }

        [HttpPost]
        public async Task<ActionResult<CreateEndpointOutDTO>> Post(CreateEndpointInDTO parameters)
        {
            var command = new CreateEndpointCommand(GetIdUser(), parameters.Path);
            return await mediator.Send(command);
        }
    }
}
