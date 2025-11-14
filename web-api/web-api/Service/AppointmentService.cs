using Microsoft.EntityFrameworkCore;
using web_api.Data;
using web_api.Entities;
using web_api.Interface;
using web_api.Model;
using web_api.Repository;

namespace web_api.Service
{
    public class AppointmentService : IAppointment
    {
        private readonly IRepository<Appointment> _appointmentRepository;
        public AppointmentService(IRepository<Appointment> appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }
        public async Task AddAppointment(AppointmentModel model)
        {
            var appointment = new Appointment
            {
                AppointmentId = Guid.NewGuid().ToString(),
                UserId = model.CustomerId,
                BranchId = model.BranchId,
                ScheduledDate = model.ScheduledDate,
                IsConfirmed = model.IsConfirmed
            };

            await _appointmentRepository.Create(appointment);
        }


        public async Task<IEnumerable<Appointment>> GetAllAppointments()
        {
            return await _appointmentRepository.GetAll()
                    .Include(a => a.User)
                    .Include(a => a.Branch)
                    .ToListAsync();
        }

        public async Task<Appointment?> GetAppointment(string appointmentId)
        {
            if (string.IsNullOrWhiteSpace(appointmentId))
                return null;

            return await _appointmentRepository.GetAll()
                .Include(a => a.User)
                .Include(a => a.Branch).Where(a => a.AppointmentId == appointmentId)
                .FirstOrDefaultAsync();
        }

        public async Task RemoveAppointment(string appointmentId)
        {
            var appointment = await _appointmentRepository.GetAll()
                .FirstOrDefaultAsync(a =>
                    a.AppointmentId.ToString() == appointmentId ||
                    a.AppointmentId == appointmentId);

            if (appointment != null)
            {
                await _appointmentRepository.Delete(appointment);
            }
        }

        public async Task UpdateAppointment(AppointmentModel model,string AppointmentId)
        {
            var appointment = await _appointmentRepository.GetAll()
                .FirstOrDefaultAsync(a => a.AppointmentId.ToString() == AppointmentId);

            if (appointment != null)
            {
                appointment.ScheduledDate = model.ScheduledDate;
                appointment.BranchId = model.BranchId;
                appointment.IsConfirmed = model.IsConfirmed;

                await _appointmentRepository.Update(appointment);
            }
        }
    }
}


