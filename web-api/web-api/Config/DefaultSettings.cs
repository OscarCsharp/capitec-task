namespace web_api.Config
{
    public class DefaultSettings
    {
        public string DefaultEmail { get; set; } = string.Empty;
        public List<string> ? DefaultRoles { get; set; }
        public Dictionary<string, DefaultUser>? DefaultUsers { get; set; }
        public Dictionary<string, DefaultBranch>? DefaultBranches { get; set; }
        
    }

    public class DefaultUser
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }

    public class DefaultBranch
    {
        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
    }
}
