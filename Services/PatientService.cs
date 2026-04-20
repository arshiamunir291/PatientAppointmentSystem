using PatientAppointmentSystem.Services.Interfaces;
using PatientAppointmentSystem.Repositories.Interfaces;
using PatientAppointmentSystem.Models.PatientModels;
using PatientAppointmentSystem.Entities;
namespace PatientAppointmentSystem.Services
{
    public class PatientService(IPatientRepository patientRepository) : IPatientService
    {
        public async Task<List<PatientListDTO>> GetPatients()
        {
            var patients= await patientRepository.GetPatientsAsync();
            return patients.Select(p=>new PatientListDTO
            {
                PatientId=p.PatientId,
                FullName=$"{p.FirstName} {p.LastName}"
            }).ToList();
        }
        public async Task<PatientDetailDTO?> GetPatientById(int id)
        {
            var patient = await patientRepository.GetPatientByIdAsync(id);
            if(patient == null) return null;
            return new PatientDetailDTO
            {
                Id = patient.PatientId,
                FullName = $"{patient.FirstName} {patient.LastName}",
                Email = patient.Email,
                City = patient.City,
                PhoneNumber = patient.PhoneNumber
            };
        }
        public async Task<PatientListDTO> AddPatient(PatientCreateDTO dto)
        {
            var patient = new Patient
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Gender = dto.Gender,
                DateOfBirth = DateOnly.Parse(dto.DateOfBirth),
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                City = dto.City
            };
            var createdPatient = await patientRepository.AddPatientAsync(patient);
            return new PatientListDTO
            {
                PatientId = createdPatient.PatientId,
                FullName = $"{createdPatient.FirstName} {createdPatient.LastName}"
            };
        }
        public async Task<PatientDetailDTO?> UpdatePatient(int id, PatientUpdateDTO dto)
        {
            var existingPatient = await patientRepository.GetPatientByIdAsync(id);
            if (existingPatient == null)
            {
                return null;
            }
            existingPatient.FirstName = dto.FirstName;
            existingPatient.LastName = dto.LastName;
            existingPatient.Gender = dto.Gender;
            existingPatient.DateOfBirth = dto.DateOfBirth;
            existingPatient.Email = dto.Email;
            existingPatient.PhoneNumber = dto.PhoneNumber;
            existingPatient.City = dto.City;
            await patientRepository.UpdatePatientAsync(existingPatient);
            return new PatientDetailDTO
            {
                Id = existingPatient.PatientId,
                FullName = $"{existingPatient.FirstName} {existingPatient.LastName}",
                Email = existingPatient.Email,
                City = existingPatient.City,
                PhoneNumber = existingPatient.PhoneNumber
            };
        }
        public async Task<bool> DeletePatient(int id)
        {
            var existingPatient = await patientRepository.GetPatientByIdAsync(id);
            if (existingPatient == null)
            {
                return false;
            }
            await patientRepository.DeletePatientAsync(existingPatient);
            return true;
        }
        public async Task<List<PatientListDTO>> GetPatientWithNoAppointments()
        {
            var patients = await patientRepository.GetPatientsWithNoAppointmentsAsync();    
            return patients.Select(p => new PatientListDTO
            {
                PatientId = p.PatientId,
                FullName = $"{p.FirstName} {p.LastName}"
            }).ToList();
        }
    }
}
