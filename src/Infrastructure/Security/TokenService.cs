using Domain.Model.Token;
using Domain.Model.User;
using Domain.Services;
using Domain.Utilities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
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
            int tokenExpirationMinutes = 60;
            int refreshTokenExpirationMinutes = 180;

            var jwtOptions = _configuration.GetSection("Jwt").Get<JwtOptions>();

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions?.Key ?? string.Empty));
            var signing = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var id = _utilities.GenerateId();
            var creation = _utilities.GetDateTime();
            var creationOffset = _utilities.GetDateTimeOffset();
            var expiration = creation.AddMinutes(tokenExpirationMinutes);

            var claims = new[]
            {
                new Claim("IdUser", user?.IdUser ?? string.Empty),
                new Claim("IdProfile", user?.IdProfile ?? string.Empty),
                new Claim(JwtRegisteredClaimNames.Jti, id),
                new Claim(JwtRegisteredClaimNames.Sub, user?.Email ?? string.Empty),
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

            var refreshToken = GenerateRefreshToken();
            var refreshTokenExpiration = creation.AddMinutes(refreshTokenExpirationMinutes);

            return new TokenModel()
            {
                Token = jwt,
                RefreshToken = refreshToken,
                Creation = creation,
                TokenExpiration = expiration,
                RefreshTokenExpiration = refreshTokenExpiration
            };
        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        public string? GetIdUser(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.ReadToken(token) as JwtSecurityToken;

            if (jwt == null)
            {
                return null;
            }

            var claimIdUser = jwt.Claims.FirstOrDefault(x => x.Type == "IdUser");

            if (claimIdUser == null)
            {
                return null;
            }

            return claimIdUser.Value;
        }
    }
}
