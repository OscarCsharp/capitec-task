using Microsoft.AspNetCore.Mvc;
using web_api.Interface;
using web_api.Model;
using web_api.Entities;

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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var appointments = await _appointmentService.GetAll();
            return Ok(appointments);
        }

        [HttpGet("{searchTerm}")]
        public async Task<IActionResult> GetAppointment(string searchTerm)
        {
            var appointment = await _appointmentService.GetAppointment(searchTerm);
            if (appointment == null)
                return NotFound(new { message = "Appointment not found." });

            return Ok(appointment);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AppointmentModel model)
        {
            await _appointmentService.Add(model);
            return Ok(new { message = "Appointment created successfully." });
        }

        [HttpPut("{appointmentId}")]
        public async Task<IActionResult> Update(string appointmentId, [FromBody] AppointmentModel model)
        {
            await _appointmentService.Update(model, appointmentId);
            return Ok(new { message = "Appointment updated successfully." });
        }

        [HttpDelete("{appointmentIdOrUserId}")]
        public async Task<IActionResult> Remove(string appointmentIdOrUserId)
        {
            await _appointmentService.Remove(appointmentIdOrUserId);
            return Ok(new { message = "Appointment removed successfully." });
        }
    }
}