using web_api.Config;
using web_api.Entities;
using web_api.Interface;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Data;

namespace web_api.Data
{
    public class DataContext : IdentityDbContext
    {
        private readonly DefaultSettings _defaultSettings;
        private readonly IEncryptionService _encryption;

        public DataContext(IEncryptionService encryption, IOptions<DefaultSettings> defaultSettings, DbContextOptions options) : base(options)
        {
            _defaultSettings = defaultSettings.Value;
            _encryption = encryption;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Define relationships
            builder.Entity<User>(b =>
            {
                b.HasMany(e => e.UserRoles)
                    .WithOne(e => e.User)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });

            builder.Entity<Role>(b =>
            {
                b.HasMany(e => e.UserRoles)
                    .WithOne(e => e.Role)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();
            });

            var users = new List<User>();
            var roles = new List<Role>();
            var userRoles = new List<UserRole>();

            // Track role name → ID mapping
            var roleIdMap = new Dictionary<string, string>();

            foreach (var kvp in _defaultSettings.DefaultUsers)
            {
                var userKey = kvp.Key;
                var defaultUser = kvp.Value;

                var passwordData = _encryption.CreatePasswordHash(defaultUser.Password);
                var normalizedUserName = defaultUser.Username.Trim().ToUpper();
                var normalizedRole = defaultUser.Role.Trim().ToUpper();

                // Ensure role exists
                if (!roleIdMap.ContainsKey(normalizedRole))
                {
                    var roleId = Guid.NewGuid().ToString();
                    roleIdMap[normalizedRole] = roleId;

                    roles.Add(new Role
                    {
                        Id = roleId,
                        Name = defaultUser.Role,
                        NormalizedName = normalizedRole,
                        Active = true
                    });
                }

                var userId = Guid.NewGuid().ToString();

                users.Add(new User
                {
                    Id = userId,
                    UserName = defaultUser.Username.Trim(),
                    NormalizedUserName = normalizedUserName,
                    HashedPassword = passwordData.HashPassword,
                    SaltPassword = passwordData.SaltPassword,
                    EmailConfirmed = false
                });

                userRoles.Add(new UserRole
                {
                    UserId = userId,
                    RoleId = roleIdMap[normalizedRole]
                });
            }

            // Seed all
            builder.Entity<User>().HasData(users);
            builder.Entity<Role>().HasData(roles);
            builder.Entity<UserRole>().HasData(userRoles);
        }
    }
}
