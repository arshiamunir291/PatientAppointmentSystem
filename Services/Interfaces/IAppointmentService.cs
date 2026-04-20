using PatientAppointmentSystem.Models.AppointmentModels;
namespace PatientAppointmentSystem.Services.Interfaces
{
    public interface IAppointmentService
    {
        Task<List<AppointmentListDTO>> GetAppointments();
        Task<AppointmentDetailDTO?> GetAppointmentById(int id);
        Task<AppointmentListDTO> AddAppointment(AppointmentCreateDTO appointment);  
        Task<AppointmentDetailDTO?> UpdateAppointment(int id, AppointmentUpdateDTO appointment);
        Task<List<AppointmentListDTO>> GetAppointmentsByPatientId(int patientId);
        Task<List<AppointmentListDTO>> GetAppointmentsByPhysicianId(int physicianId);
    }
}
