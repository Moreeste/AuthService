using Application.Catalogue.Queries;
using Domain.Model.User;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.V1
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CatalogueController : MainController
    {
        public CatalogueController(IMediator mediator) : base(mediator)
        {

        }

        [HttpGet("UserStatus")]
        public async Task<IEnumerable<UserStatus>> GetUserStatus()
        {
            var query = new GetUserStatusQuery();
            return await mediator.Send(query);
        }

        [HttpGet("Genders")]
        public async Task<IEnumerable<Gender>> GetGenders()
        {
            var query = new GetGendersQuery();
            return await mediator.Send(query);
        }
    }
}
