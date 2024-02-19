using Domain.Model.Token;
using Domain.Model.User;
using Domain.Services;
using Domain.Utilities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Security
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly IUtilities _utilities;

        public TokenService(IConfiguration configuration, IUtilities utilities)
        {
            _configuration = configuration;
            _utilities = utilities;
        }
        
        public TokenModel GenerateToken(UserModel user)
        {
            var jwtOptions = _configuration.GetSection("Jwt").Get<JwtOptions>();

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions?.Key ?? string.Empty));
            var signing = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var id = _utilities.GenerateId();
            var creation = _utilities.GetDateTime();
            var creationOffset = _utilities.GetDateTimeOffset();
            var expiration = _utilities.GetDateTime().AddMinutes(60);

            var claims = new[]
            {
                new Claim("IdUser", user?.IdUser ?? string.Empty),
                new Claim(JwtRegisteredClaimNames.Jti, id),
                new Claim(JwtRegisteredClaimNames.Sub, jwtOptions?.Subject ?? string.Empty),
                new Claim(JwtRegisteredClaimNames.Iat, creationOffset.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer),
            };

            var token = new JwtSecurityToken(
                issuer: jwtOptions?.Issuer,
                audience: jwtOptions?.Audience,
                claims: claims,
                expires: expiration,
                notBefore: creation,
                signingCredentials: signing);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return new TokenModel()
            {
                Token = jwt,
                Expiration = expiration
            };
        }
    }
}
