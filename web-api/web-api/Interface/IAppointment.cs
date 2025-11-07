using web_api.Entities;
using web_api.Model;

namespace web_api.Interface
{

    public interface IAppointment
    {
        Task<IEnumerable<Appointment>> GetAll();
        Task Add(AppointmentModel model);
        Task Remove(string AppointmentIDOrName);
        Task Update(AppointmentModel model, string AppointmentId);
        Task<Appointment> GetAppointment(string searchTerm);
    }
}
