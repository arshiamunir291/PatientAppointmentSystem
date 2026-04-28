using PatientAppointmentSystem.Entities;
namespace PatientAppointmentSystem.Repositories.Interfaces
{
    public interface IPhysicianRepository
    {
        Task<List<Physician>> GetAllPhysicainsAsync();
        Task<Physician?> GetPhysicianByIdAsync(int id);   
        Task<Physician> AddPhysicianAsync(Physician physician);
        Task<Physician?> UpdatePhysicianAsync(Physician physician);
        Task DeletePhysicianAsync(Physician physician);
        Task<List<Physician>> GetPhysicianWithNoAppointmentAsync();
        Task<List<Physician>> GetPhysicianWithAppointmentAsync();
    }
}
