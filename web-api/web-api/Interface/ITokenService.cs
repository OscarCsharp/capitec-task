namespace web_api.Interface
{
    public interface ITokenService
    {
        Task<string> GenerateJWTToken(string userIdOrName);
    }
}
