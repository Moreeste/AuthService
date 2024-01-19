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

        public string GenerateSalt()
        {
            string salt = string.Empty;
            byte[] saltBytes = new byte[32];

            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(saltBytes);
            }

            salt = Convert.ToBase64String(saltBytes);

            return salt;
        }

        public string GenerateHash(string password, string salt, int iterations)
        {
            string hashedPassword = string.Empty;
            byte[] saltByte = Convert.FromBase64String(salt);

            using (var pbkdf2 = new Rfc2898DeriveBytes(password, saltByte, iterations, HashAlgorithmName.SHA256))
            {
                byte[] hashBytes = pbkdf2.GetBytes(32);
                StringBuilder stringBuilder = new StringBuilder();

                foreach (byte b in hashBytes)
                {
                    stringBuilder.Append(b.ToString("x2"));
                }

                hashedPassword = stringBuilder.ToString();

                return hashedPassword;
            }
        }
    }
}
