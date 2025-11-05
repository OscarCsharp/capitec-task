using web_api.Model;

namespace web_api.Interface
{
    public interface IEncryptionService
    {
        EncryptionResponseModel CreatePasswordHash(string password);
        bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);
    }
}
