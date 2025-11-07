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
        public async Task Add(AppointmentModel model)
        {
            var appointment = new Appointment
            {
                AppointmentId = Guid.NewGuid().ToString(),
                Id = model.CustomerId,
                BranchId = model.BranchId,
                ScheduledDate = model.ScheduledDate,
                IsConfirmed = model.IsConfirmed
            };

            await _appointmentRepository.Create(appointment);
        }


        public async Task<IEnumerable<Appointment>> GetAll()
        {
            return await _appointmentRepository.GetAll()
                    .Include(a => a.User)
                    .Include(a => a.Branch)
                    .ToListAsync();
        }

        public async Task<Appointment?> GetAppointment(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return null;

            return await _appointmentRepository.GetAll()
                .Include(a => a.User)
                .Include(a => a.Branch)
                .FirstOrDefaultAsync(a =>
                    a.AppointmentId.ToString().Equals(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    a.Id.Equals(searchTerm, StringComparison.OrdinalIgnoreCase));
        }

        public async Task Remove(string appointmentIdOrUserId)
        {
            var appointment = await _appointmentRepository.GetAll()
                .FirstOrDefaultAsync(a =>
                    a.AppointmentId.ToString() == appointmentIdOrUserId ||
                    a.Id == appointmentIdOrUserId);

            if (appointment != null)
            {
                await _appointmentRepository.Delete(appointment);
            }
        }

        public async Task Update(AppointmentModel model,string AppointmentId)
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


