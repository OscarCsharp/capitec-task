namespace web_api.Config
{
    public class ApplicationSettings
    {
        public string JWT_Secret { get; set; } = string.Empty;
        public List<string>? Client_URL { get; set; }
        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
        public string ClientApp { get; set; } = string.Empty;
    }
}
