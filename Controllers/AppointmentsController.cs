using PatientAppointmentSystem.Models.AppointmentModels;
using Microsoft.AspNetCore.Mvc;
using PatientAppointmentSystem.Services.Interfaces;

namespace PatientSystem.Controllers
{
    [Route("appointments")]
    [ApiController]
    public class AppointmentsController(IAppointmentService appointmentService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAppointments()
        {
            var appointments = await appointmentService.GetAppointments();
            return Ok(appointments);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppointmentById(int id)
        {
            var appointment = await appointmentService.GetAppointmentById(id);
            if (appointment == null)
            {
                return NotFound(new { message = "Appointment with this ID not found" });
            }
            return Ok(appointment);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAppointment([FromBody]AppointmentCreateDTO appointment)
        {
            var createdAppointment = await appointmentService.AddAppointment(appointment);
            return CreatedAtAction(nameof(GetAppointmentById), new { id = createdAppointment.AppointmentId }, createdAppointment);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAppointment(int id, AppointmentUpdateDTO appointment)
        {
            var updatedAppointment = await appointmentService.UpdateAppointment(id, appointment);
            if (updatedAppointment == null)
            {
                return NotFound(new { message = "Appointment with this ID not found" });
            }
            return Ok(updatedAppointment);
        }
        [HttpGet("patient/{patientId}")]
        public async Task<IActionResult> GetAppointmentsByPatientId(int patientId)
        {
            var appointments = await appointmentService.GetAppointmentsByPatientId(patientId);
            return Ok(appointments);
        }
        [HttpGet("physician/{physicianId}")]
        public async Task<IActionResult> GetAppointmentsByPhysicianId(int physicianId)
        {
            var appointments = await appointmentService.GetAppointmentsByPhysicianId(physicianId);
            return Ok(appointments);
        }

    }
}
