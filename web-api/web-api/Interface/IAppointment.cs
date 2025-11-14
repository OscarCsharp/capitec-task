using web_api.Entities;
using web_api.Model;

namespace web_api.Interface
{

    public interface IAppointment
    {
        Task<IEnumerable<Appointment>> GetAllAppointments();
        Task AddAppointment(AppointmentModel model);
        Task RemoveAppointment(string AppointmentId);
        Task UpdateAppointment(AppointmentModel model, string AppointmentId);
        Task<Appointment> GetAppointment(string appointmentId);
    }
}
