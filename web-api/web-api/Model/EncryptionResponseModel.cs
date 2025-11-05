namespace web_api.Model
{
    public class EncryptionResponseModel
    {
        public byte[]? HashPassword { get; set; }
        public byte[]? SaltPassword { get; set; }
    }
}
