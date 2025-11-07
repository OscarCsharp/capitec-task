using System.ComponentModel.DataAnnotations;

namespace web_api.Entities
{
    public class Branch
    {
        [Key]
        public string BranchId { get; set; } = string.Empty;
        [Required]
        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
    }
}
