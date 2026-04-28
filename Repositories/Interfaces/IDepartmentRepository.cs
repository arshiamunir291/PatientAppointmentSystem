using PatientAppointmentSystem.Entities;

namespace PatientAppointmentSystem.Repositories.Interfaces
{
    public interface IDepartmentRepository
    {
        Task<List<Department>> GetAllDepartmentsAsync();
        Task<string?> GetDepartmentNameById(int id);
    }
}
