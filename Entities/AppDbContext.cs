using Microsoft.EntityFrameworkCore;

namespace PatientAppointmentSystem.Entities;

public partial class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public  DbSet<Appointment> Appointments { get; set; }

    public  DbSet<Department> Departments { get; set; }

    public  DbSet<Patient> Patients { get; set; }

    public  DbSet<Physician> Physicians { get; set; }

   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
