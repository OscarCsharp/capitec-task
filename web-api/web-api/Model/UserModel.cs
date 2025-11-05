using System.ComponentModel.DataAnnotations;

namespace web_api.Model
{
    public class UserModel
    {
        public required string UserName { get; set; }
        public required string Email { get; set; }
        [DataType(DataType.Password)]
        public required string Password { get; set; }
        public required string Role { get; set; }
    }
}
