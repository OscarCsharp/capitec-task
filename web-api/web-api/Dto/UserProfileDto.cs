namespace web_api.Dto
{
    public class UserProfileDto
    {
        public string Id { get; set; } = string.Empty;
        public string EmailAddress { get; set; } = string.Empty ;
        public bool Deactivated { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }
}
