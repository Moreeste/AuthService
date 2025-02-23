using Domain.Exceptions;
using Domain.Repository;
using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Text.RegularExpressions;

namespace Infrastructure.Middleware
{
    public class AuthMiddleware : IMiddleware
    {
        private readonly IProfileRepository _profileRepository;
        private readonly IProfilePermissionRepository _profilePermissionRepository;
        private readonly IEndpointRepository _endpointRepository;

        public AuthMiddleware(IProfileRepository profileRepository, IProfilePermissionRepository profilePermissionRepository, IEndpointRepository endpointRepository)
        {
            _profileRepository = profileRepository;
            _profilePermissionRepository = profilePermissionRepository;
            _endpointRepository = endpointRepository;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var path = RemoveGuidsFromPath(context.Request.Path);
            var method = context.Request.Method;
            var profile = GetProfile(context.Request.Headers.Authorization.ToString());
            
            var endpointList = await _endpointRepository.GetEndpointByPath(path);
            if (endpointList.Count() == 0)
            {
                throw new NotFoundException("No existe endpoint");
            }

            var endpoint = endpointList.Where(x => x.Method == method).FirstOrDefault();
            if (endpoint == null)
            {
                throw new NotFoundException("Método no permitido");
            }



            await next(context);
        }

        private string? GetProfile(string? authorizationHeader)
        {
            string? profile = null;
            
            if (!string.IsNullOrEmpty(authorizationHeader) && authorizationHeader.StartsWith("Bearer "))
            {
                var token = authorizationHeader.Split(' ')[1];
                var handler = new JwtSecurityTokenHandler();
                if (handler.CanReadToken(token))
                {
                    var jwtToken = handler.ReadJwtToken(token);
                    var idProfileClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "IdProfile");

                    if (idProfileClaim != null)
                    {
                        profile = idProfileClaim.Value;
                    }
                }
            }

            return profile;
        }

        private string RemoveGuidsFromPath(string path)
        {
            return Regex.Replace(path, @"(/([a-f0-9]{8}-[a-f0-9]{4}-[a-f0-9]{4}-[a-f0-9]{4}-[a-f0-9]{12}))+", "");
        }
    }
}
