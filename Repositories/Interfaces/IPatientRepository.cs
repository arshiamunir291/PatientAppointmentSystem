using PatientAppointmentSystem.Entities;

namespace PatientAppointmentSystem.Repositories.Interfaces
{
    public interface IPatientRepository
    {
        Task<List<Patient>> GetPatientsAsync();
        Task<Patient?> GetPatientByIdAsync(int id);
        Task<Patient> AddPatientAsync(Patient patient);
        Task UpdatePatientAsync(Patient patient);
        Task DeletePatientAsync(Patient patient);
        Task<List<Patient>> GetPatientsWithNoAppointmentsAsync();
    }
}
