using PatientAppointmentSystem.Repositories.Interfaces;
using PatientAppointmentSystem.Entities;
using Microsoft.EntityFrameworkCore;
namespace PatientManagementSystem.Repositories
{
    public class PhysicianRepository(AppDbContext context) : IPhysicianRepository
    {
         public async Task<List<Physician>> GetAllPhysicainsAsync()
        {
            return await context.Physicians.AsNoTracking().ToListAsync();
        }
        public async Task<Physician?> GetPhysicianByIdAsync(int id)
        {
            return await context.Physicians
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.PhysicianId == id);
        }
        public async Task<Physician> AddPhysicianAsync(Physician physician)
        {
            context.Physicians.Add(physician);
            await context.SaveChangesAsync();
            return physician;

        }
        public async Task<Physician?> UpdatePhysicianAsync(Physician physician)
        {
            context.Physicians.Update(physician);
            await context.SaveChangesAsync();
            return physician;

        }
        public async Task DeletePhysicianAsync(Physician physician)
        {
            context.Physicians.Remove(physician);
            await context.SaveChangesAsync();
        }
        public async Task<List<Physician>> GetPhysicianWithNoAppointmentAsync()
        {
            return await context.Physicians.AsNoTracking()
                .Where(d => !context.Appointments.Any(a => a.PhysicianId == d.PhysicianId)).AsNoTracking()
                .ToListAsync();
        }
        public async Task<List<Physician>> GetPhysicianWithAppointmentAsync()
        {
            return await context.Physicians.AsNoTracking()
                .Where(d => context.Appointments.Any(a => a.PhysicianId == d.PhysicianId)).AsNoTracking()
                .ToListAsync();
        }

    }
}
