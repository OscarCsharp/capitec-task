using Microsoft.AspNetCore.Mvc;
using web_api.Interface;
using web_api.Model;
using web_api.Entities;
using Microsoft.AspNetCore.Authorization;

namespace web_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointment _appointmentService;

        public AppointmentController(IAppointment appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet("GetAllAppointments")]
        public async Task<IActionResult> GetAll()
        {
            var appointments = await _appointmentService.GetAllAppointments();
            return Ok(appointments);
        }

        [HttpGet("GetAppointment{appointmentId}")]
        public async Task<IActionResult> GetAppointment(string appointmentId)
        {
            var appointment = await _appointmentService.GetAppointment(appointmentId);
            if (appointment == null)
                return NotFound(new { message = "Appointment not found." });

            return Ok(appointment);
        }


        [HttpGet("UserAppointments/{userId}")]
        public async Task<IActionResult> GetAppointmentsByUserId(string userId)
        {
            var appointments = await _appointmentService.GetAllAppointments();
            var userAppointments = appointments.Where(a => a.UserId == userId).ToList();
            return Ok(userAppointments);
        }


        [HttpPost("AddAppointment")]
        public async Task<IActionResult> Add([FromBody] AppointmentModel model)
        {
            await _appointmentService.AddAppointment(model);
            return Ok(new { message = "Appointment created successfully." });
        }

        [HttpPut("UpdateAppointment/{appointmentId}")]
        public async Task<IActionResult> Update(string appointmentId, [FromBody] AppointmentModel model)
        {
            await _appointmentService.UpdateAppointment(model, appointmentId);
            return Ok(new { message = "Appointment updated successfully." });
        }

        [HttpDelete("RemoveAppointment/{appointmentId}")]
        public async Task<IActionResult> Remove(string appointmentIdOrUserId)
        {
            await _appointmentService.RemoveAppointment(appointmentIdOrUserId);
            return Ok(new { message = "Appointment removed successfully." });
        }
    }
}