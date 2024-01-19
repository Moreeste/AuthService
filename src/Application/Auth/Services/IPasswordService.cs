namespace Application.Auth.Services
{
    public interface IPasswordService
    {
        int GetIterations(string idUser);
        byte[] GenerateSalt();
        string GenerateHash(string password, byte[] salt, int iterations);
    }
}
