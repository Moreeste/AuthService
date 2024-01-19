using System.Security.Cryptography;
using System.Text;

namespace Application.Auth.Services
{
    public class PasswordService : IPasswordService
    {
        public int GetIterations(string idUser)
        {
            int iterations;

            Guid guid = Guid.Parse(idUser);
            byte[] guidByte = guid.ToByteArray();
            long guidNumber = BitConverter.ToInt64(guidByte, 0);
            long residue = guidNumber % 10001;
            long randomNumber = Math.Abs(residue) + 10000;
            iterations = (int)randomNumber;

            return iterations;
        }

        public byte[] GenerateSalt()
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] salt = new byte[32];
                rng.GetBytes(salt);
                return salt;
            }
        }

        public string GenerateHash(string password, byte[] salt, int iterations)
        {
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA256))
            {
                byte[] hashBytes = pbkdf2.GetBytes(32);
                
                StringBuilder stringBuilder = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    stringBuilder.Append(b.ToString("x2"));
                }

                return stringBuilder.ToString();
            }
        }
    }
}
