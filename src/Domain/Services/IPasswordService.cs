namespace Domain.Services
{
    public interface IPasswordService
    {
        int GetIterations(string? idUser);
        string GenerateSalt();
        string GenerateHash(string? password, string? salt, int iterations);
    }
}
