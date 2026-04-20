using PatientAppointmentSystem.Models.PatientModels;
namespace PatientAppointmentSystem.Services.Interfaces
{
    public interface IPatientService
    {
            Task<List<PatientListDTO>> GetPatients();
            Task<PatientDetailDTO?> GetPatientById(int id);
            Task<PatientListDTO> AddPatient(PatientCreateDTO patient);
            Task<PatientDetailDTO?> UpdatePatient(int id,PatientUpdateDTO patient);
            Task<bool> DeletePatient(int id);
            Task<List<PatientListDTO>> GetPatientWithNoAppointments();
    }
}
