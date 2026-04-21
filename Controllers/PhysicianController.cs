using PatientAppointmentSystem.Models.PhysicianModels;
using Microsoft.AspNetCore.Mvc;
using PatientAppointmentSystem.Services.Interfaces;

namespace PatientAppointmentSystem.Controllers
{
    [Route("Physicians/")]
    [ApiController]
    public class PhysicianController(IPhysicianService service) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllPhysicians()
        {
            var physician = await service.GetPhysicians();
            return Ok(physician);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPhysicianById(int id)
        {
            var physician = await service.GetPhysicianById(id);
            if (physician == null)
                return NotFound(new { message = "Physician with this Id not found" });
            return Ok(physician);
        }
        [HttpPost]
        public async Task<IActionResult> CreatePhysician(PhysicianCreateDTO physician)
        {
            var createdPhysician = await service.AddPhysician(physician);
            return CreatedAtAction(nameof(GetPhysicianById), new { id = createdPhysician.PhysicianId }, createdPhysician);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePhysician(int id, PhysicianUpdateDTO physician)
        {
            var updatedPhysician = await service.UpdatePhysician(id, physician);
            if (updatedPhysician == null)
                return NotFound(new { message = "Physician with this Id not found" });
            return Ok(updatedPhysician);
        }
        [HttpDelete]
        public async Task<IActionResult> DeletePhysician(int id)
        {
            var isDeleted = await service.DeletePhysician(id);
            if (!isDeleted)
                return NotFound(new { message = "Physician with this Id not found" });
            return NoContent();
        }
        [HttpGet("no appointments")]
        public async Task<IActionResult> GetPhysicianWithNoAppointments()
        {
            var doctors = await service.GetPhysicianWithNoAppointments();
            return Ok(doctors);
        }
        [HttpGet("with-appointments")]
        public async Task<IActionResult> GetPhysicianWithAppointments()
        {
            var doctors = await service.GetPhysicianWithAppointments();
            return Ok(doctors);
        }
    }
}
