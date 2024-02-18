using Domain.Model.Token;
using Domain.Model.User;
using Domain.Services;

namespace Infrastructure.Security
{
    public class TokenService : ITokenService
    {
        public TokenModel GenerateToken(UserModel user)
        {
            throw new NotImplementedException();
        }
    }
}
