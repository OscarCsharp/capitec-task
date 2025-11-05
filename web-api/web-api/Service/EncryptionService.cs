using web_api.Interface;
using web_api.Model;

namespace web_api.Service
{
    public class EncryptionService : IEncryptionService
    {
        public EncryptionResponseModel CreatePasswordHash(string password)
        {

            if (password == null) throw new ArgumentNullException("Password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.",
                 "password");

            byte[] passwordHash, passwordSalt;
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
            EncryptionResponseModel _encryptResponse = new EncryptionResponseModel
            {
                HashPassword = passwordHash,
                SaltPassword = passwordSalt
            };
            return _encryptResponse;
        }

        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            try
            {
                if (password == null) throw new ArgumentNullException("password");
                if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.",
                     "password");
                if (passwordHash.Length != 64) throw new ArgumentException("Invalid length of password (64 bytes expected).",
                     "passwordHash");
                if (passwordSalt.Length != 128) throw new ArgumentException("Invalid lenght of password salt (128 bytes expected).",
                     "passwordHash");

                using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
                {
                    var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                    for (int i = 0; i < computedHash.Length; i++)
                    {
                        if (computedHash[i] != passwordHash[i]) return false;
                    }
                }

                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
