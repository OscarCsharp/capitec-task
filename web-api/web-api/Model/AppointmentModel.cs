using System.ComponentModel.DataAnnotations;
using web_api.Entities;

namespace web_api.Model
{
    public class AppointmentModel
    {
        public string CustomerId { get; set; } = string.Empty;
        public string BranchId { get; set; } = string.Empty;
        public DateTime ScheduledDate { get; set; }

        public bool IsConfirmed { get; set; } = false;
    }
}
