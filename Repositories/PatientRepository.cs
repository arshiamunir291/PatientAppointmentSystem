
using PatientAppointmentSystem.Repositories.Interfaces;
using PatientAppointmentSystem.Entities;
using Microsoft.EntityFrameworkCore;
namespace PatientAppointmentSystem.Repositories
{
    public class PatientRepository(AppDbContext context) : IPatientRepository
    {
        public async Task<List<Patient>> GetPatientsAsync()
        {
            return await context.Patients.ToListAsync();
        }
        public async Task<Patient?> GetPatientByIdAsync(int id)
        {
            return await context.Patients.FindAsync(id);
        }
        public async Task<Patient> AddPatientAsync(Patient patient)
        {
            context.Patients.Add(patient);
            await context.SaveChangesAsync();
            return patient;
        }
        public async Task UpdatePatientAsync(Patient patient)
        {
            context.Patients.Update(patient);
            await context.SaveChangesAsync();
        }
      

        public async Task DeletePatientAsync(Patient patient)
        {
                context.Patients.Remove(patient);
                await context.SaveChangesAsync();
            
        }
        public async Task<List<Patient>> GetPatientsWithNoAppointmentsAsync()
        {
            return await context.Patients.AsNoTracking()
                .Where(p=>p.Appointments== null || !p.Appointments.Any())
                .ToListAsync();
        }
    }
}
