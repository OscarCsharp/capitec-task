using Microsoft.AspNetCore.Identity;

namespace web_api.Entities
{
    public class Role : IdentityRole
    {
        public bool Active { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
