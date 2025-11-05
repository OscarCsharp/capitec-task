using Microsoft.AspNetCore.Identity;
using System.Net.NetworkInformation;

namespace web_api.Entities
{
    public class User : IdentityUser
    {
        public byte[]? SaltPassword { get; set; } 
        public byte[]? HashedPassword { get; set; }
        public string EmailAddress { get; set; } = string.Empty;
        public bool Deactivated { get; set; } 
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public virtual ICollection<UserRole>? UserRoles { get; set; }
    }
}
