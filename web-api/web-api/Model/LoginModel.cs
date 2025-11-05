using System.ComponentModel.DataAnnotations;

namespace web_api.Model
{
    public class LoginModel
    {
        public required string UserName { get; set; }
        [DataType(DataType.Password)]
        public required string Password { get; set; }
    }
}
