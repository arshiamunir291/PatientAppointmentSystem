using PatientAppointmentSystem.Models.PhysicianModels;
namespace PatientAppointmentSystem.Services.Interfaces
{
    public interface IPhysicianService
    {
        Task<List<PhysicianListDTO>> GetPhysicians();
        Task<PhysicianDetailDTO?> GetPhysicianById(int id);
        Task<PhysicianListDTO> AddPhysician(PhysicianCreateDTO physician);
        Task<PhysicianDetailDTO?> UpdatePhysician(int id, PhysicianUpdateDTO physician);
        Task<bool> DeletePhysician(int id);
        Task<List<PhysicianListDTO>> GetPhysicianWithNoAppointments();
    }
}
