using PatientAppointmentSystem.Repositories.Interfaces;
using PatientAppointmentSystem.Entities;
using Microsoft.EntityFrameworkCore;
namespace PatientManagementSystem.Repositories
{
    public class PhysicianRepository(AppDbContext context) : IPhysicianRepository
    {
         public async Task<List<Physician>> GetAllPhysicainsAsync()
        {
            return await context.Physicians.Include(p=>p.Department).ToListAsync();
        }
        public async Task<Physician?> GetPhysicianByIdAsync(int id)
        {
            return await context.Physicians
                .Include(p => p.Department)
                .FirstOrDefaultAsync(p => p.PhysicianId == id);
        }
        public async Task<Physician> AddPhysicianAsync(Physician physician)
        {
            context.Physicians.Add(physician);
            await context.SaveChangesAsync();
            return await context.Physicians
                .Include(p => p.Department)
                .FirstOrDefaultAsync(p => p.PhysicianId == physician.PhysicianId)
                ?? throw new InvalidOperationException("Physician could not be found after adding.");
        }
        public async Task<Physician?> UpdatePhysicianAsync(Physician physician)
        {
            context.Physicians.Update(physician);
            await context.SaveChangesAsync();
            return await context.Physicians
               .Include(p => p.Department)
               .FirstOrDefaultAsync(p => p.PhysicianId == physician.PhysicianId);
               //?? throw new InvalidOperationException("Physician could not be found.");
        }
        public async Task DeletePhysicianAsync(Physician physician)
        {
            context.Physicians.Remove(physician);
            await context.SaveChangesAsync();
        }
        public async Task<List<Physician>> GetPhysicianWithNoAppointmentAsync()
        {
            return await context.Physicians.Include(p=>p.Department)
                .Where(d => !context.Appointments.Any(a => a.PhysicianId == d.PhysicianId)).AsNoTracking()
                .ToListAsync();
        }

    }
}
