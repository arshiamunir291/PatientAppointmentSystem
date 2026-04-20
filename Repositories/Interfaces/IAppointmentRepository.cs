using PatientAppointmentSystem.Entities;
using PatientAppointmentSystem.Models.AppointmentModels;
namespace PatientAppointmentSystem.Repositories.Interfaces
{
    public interface IAppointmentRepository
    {
        Task<List<Appointment>> GetAllAppointmentsAsync();
        Task<Appointment?> GetAppointmentByIdAsync(int id);
        Task<Appointment> AddAppointmentAsync(Appointment appointment);
        Task UpdateAppointmentAsync(Appointment appointment);

        Task<List<Appointment>> GetAppointmentsByPatientIdAsync(int patientId);
        Task<List<Appointment>> GetAppointmentsByPhysicianIdAsync(int physicianId);
    }
}
