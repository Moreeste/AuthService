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
            string idUser = string.Empty;
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity != null)
            {
                var claimIdUser = identity.Claims.FirstOrDefault(x => x.Type == "IdUser");

                if (claimIdUser != null)
                {
                    idUser = claimIdUser.Value;
                }
            }

            return idUser;
        }

        protected string GetIdProfile()
        {
            string idProfile = string.Empty;
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity != null)
            {
                var claimIdProfile = identity.Claims.FirstOrDefault(x => x.Type == "IdProfile");

                if (claimIdProfile != null)
                {
                    idProfile = claimIdProfile.Value;
                }
            }

            return idProfile;
        }
    }
}
