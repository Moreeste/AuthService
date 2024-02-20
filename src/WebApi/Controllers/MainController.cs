using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        protected readonly IMediator mediator;
        
        public MainController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        protected string GetIdUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            string id = identity.Claims.FirstOrDefault(X => X.Type == "IdUser").Value;
            return id;
        }
    }
}
