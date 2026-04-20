using Microsoft.AspNetCore.Mvc;
using PatientAppointmentSystem.Models.PatientModels;
using PatientAppointmentSystem.Services.Interfaces;

namespace PatientManagementSystem.Controllers
{
    [Route("patient/")]
    [ApiController]
    public class PatientController(IPatientService service) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllPatients()
        {
            var patients = await service.GetPatients();
            return Ok(patients);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var patient = await service.GetPatientById(id);
            if (patient == null)
                return NotFound(new { message = "Patient with this Id not found" });
            return Ok(patient);
        }
        [HttpPost]
        public async Task<IActionResult> Create(PatientCreateDTO patient)
        {
            var createdPatient = await service.AddPatient(patient);
            return CreatedAtAction(nameof(GetById), new { id = createdPatient.PatientId }, createdPatient);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PatientUpdateDTO patient)
        {
            var updatedPatient = await service.UpdatePatient(id, patient);
            if (updatedPatient == null)
                return NotFound(new { message = "Patient with this Id not found" });
            return Ok(updatedPatient);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var isDeleted = await service.DeletePatient(id);
            if (!isDeleted)
                return NotFound("Patient with this Id not found");
            return NoContent();
        }
        [HttpGet("no-appointments")]
        public async Task<IActionResult> GetPatientsWithNoAppointments()
        {
            var patients = await service.GetPatientWithNoAppointments();
            return Ok(patients);
        }
    }
}
