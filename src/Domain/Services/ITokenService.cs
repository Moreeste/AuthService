using Domain.Model.Token;
using Domain.Model.User;

namespace Domain.Services
{
    public interface ITokenService
    {
        TokenModel GenerateToken(UserModel user);
    }
}
