using System.ComponentModel.DataAnnotations;

namespace web_api.Entities
{
    public class Appointment
    {
        [Key]
        public string AppointmentId { get; set; } = string.Empty;

        [Required]
        public string Id { get; set; } = string.Empty;
        public User? User { get; set; }

        [Required]
        public string BranchId { get; set; } = string.Empty;
        public Branch? Branch { get; set; }

        [Required]
        public DateTime ScheduledDate { get; set; }

        public bool IsConfirmed { get; set; } = false;
    }
}
