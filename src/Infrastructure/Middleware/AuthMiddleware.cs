using Domain.Exceptions;
using Domain.Model.User;
using Domain.Repository;
using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Text.RegularExpressions;

namespace Infrastructure.Middleware
{
    public class AuthMiddleware : IMiddleware
    {
        private readonly IUserPropertiesRepository _userPropertiesRepository;
        private readonly IProfileRepository _profileRepository;
        private readonly IProfilePermissionRepository _profilePermissionRepository;
        private readonly IEndpointRepository _endpointRepository;

        public AuthMiddleware(IUserPropertiesRepository userPropertiesRepository, IProfileRepository profileRepository, IProfilePermissionRepository profilePermissionRepository, IEndpointRepository endpointRepository)
        {
            _userPropertiesRepository = userPropertiesRepository;
            _profileRepository = profileRepository;
            _profilePermissionRepository = profilePermissionRepository;
            _endpointRepository = endpointRepository;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var path = RemoveGuidsFromPath(context.Request.Path);
            var method = context.Request.Method;
            var authorizationHeader = context.Request.Headers.Authorization.ToString();
            var user = GetUserData(authorizationHeader);
            
            var endpointList = await _endpointRepository.GetEndpointByPath(path);
            if (endpointList.Count() == 0)
            {
                throw new NotFoundException("No existe endpoint.");
            }

            var endpoint = endpointList.Where(x => x.Method == method).FirstOrDefault();
            if (endpoint == null)
            {
                throw new NotFoundException("Método no permitido.");
            }

            if (!endpoint.Active)
            {
                throw new AuthException("Endpoint inactivo.");
            }

            if (!endpoint.IsPublic)
            {
                await ValidateUser(user.IdUser);
                await ValidateProfile(user.IdProfile);

                if (!endpoint.IsForEveryone)
                {

                }
            }

            await next(context);
        }

        private async Task ValidateUser(string? idUser)
        {
            if (string.IsNullOrEmpty(idUser))
            {
                throw new AuthException("Ocurrió un error al obtener id de usuario.");
            }

            var userProperties = await _userPropertiesRepository.GetUserProperties(idUser);

            if (userProperties == null)
            {
                throw new AuthException("No existe usuario.");
            }

            if (userProperties.Status == (int)Domain.Enums.UserStatus.Inactive)
            {
                throw new BusinessException("Usuario inactivo.");
            }

            if (userProperties.Status == (int)Domain.Enums.UserStatus.Blocked)
            {
                throw new BusinessException("Usuario bloqueado.");
            }
        }

        private async Task ValidateProfile(string?  idProfile)
        {
            if (string.IsNullOrEmpty(idProfile))
            {
                throw new AuthException("Ocurrió un error al obtener perfil de usuario.");
            }

            if (idProfile != "00000000-0000-0000-0000-000000000000")
            {
                var profileProperties = await _profileRepository.GetProfileById(idProfile);

                if (profileProperties == null)
                {
                    throw new AuthException("No existe perfil.");
                }

                if (!profileProperties.Active)
                {
                    throw new AuthException("Perfil inactivo.");
                }
            }
        }

        private AuthUser GetUserData(string? authorizationHeader)
        {
            string? idUser = null;
            string? idProfile = null;
            
            if (!string.IsNullOrEmpty(authorizationHeader) && authorizationHeader.StartsWith("Bearer "))
            {
                var token = authorizationHeader.Split(' ')[1];
                var handler = new JwtSecurityTokenHandler();
                if (handler.CanReadToken(token))
                {
                    var jwtToken = handler.ReadJwtToken(token);

                    var idUserClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "IdUser");
                    if (idUserClaim != null)
                    {
                        idUser = idUserClaim.Value;
                    }

                    var idProfileClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "IdProfile");
                    if (idProfileClaim != null)
                    {
                        idProfile = idProfileClaim.Value;
                    }
                }
            }

            return new AuthUser(idUser, idProfile);
        }

        private string RemoveGuidsFromPath(string path)
        {
            return Regex.Replace(path, @"(/([a-f0-9]{8}-[a-f0-9]{4}-[a-f0-9]{4}-[a-f0-9]{4}-[a-f0-9]{12}))+", "");
        }
    }
}
