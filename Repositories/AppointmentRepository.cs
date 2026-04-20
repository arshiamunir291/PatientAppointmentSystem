using PatientAppointmentSystem.Repositories.Interfaces;
using PatientAppointmentSystem.Entities;
using Microsoft.EntityFrameworkCore;
namespace PatientAppointmentSystem.Repositories
{
    public class AppointmentRepository(AppDbContext context) : IAppointmentRepository
    {
        public async Task<List<Appointment>> GetAllAppointmentsAsync()
        {
            return await context.Appointments.Include(a=>a.Patient).Include(a=>a.Physician).ToListAsync();
        }
        public async Task<Appointment?> GetAppointmentByIdAsync(int id)
        {
            return await context.Appointments.Include(a=>a.Patient).Include(a=>a.Physician).FirstOrDefaultAsync(a=>a.AppointmentId==id);
        }
        public async Task<Appointment> AddAppointmentAsync(Appointment appointment)
        {
            context.Appointments.Add(appointment);
            await context.SaveChangesAsync();
            return appointment;
        }
        public async Task UpdateAppointmentAsync(Appointment appointment)
        {
            context.Appointments.Update(appointment);
            await context.SaveChangesAsync();
        }
        public async Task<List<Appointment>> GetAppointmentsByPatientIdAsync(int patientId)
        {
            return await context.Appointments.Include(a=>a.Patient).Include(a=>a.Physician).Where(a => a.PatientId == patientId).AsNoTracking().ToListAsync();
        }
        public async Task<List<Appointment>> GetAppointmentsByPhysicianIdAsync(int physicianId)
        {
            return await context.Appointments.Include(a=>a.Physician).Include(a=>a.Patient).Where(a => a.PhysicianId == physicianId).AsNoTracking().ToListAsync();
        }

    }
}
