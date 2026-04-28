using Microsoft.EntityFrameworkCore;
using PatientAppointmentSystem.Entities;
using PatientAppointmentSystem.Repositories.Interfaces;

namespace PatientAppointmentSystem.Repositories
{
    public class DepartmentRepository(AppDbContext context) : IDepartmentRepository
    {
        public async Task<List<Department>> GetAllDepartmentsAsync()
        {
            return await context.Departments.AsNoTracking().ToListAsync();
        }
        public async Task<string?> GetDepartmentNameById(int id)
        {
            return await context.Departments
                .Where(d => d.DepartmentId == id)
                .Select(d => d.DepartmentName)
                .FirstOrDefaultAsync();
        }
    }
}
