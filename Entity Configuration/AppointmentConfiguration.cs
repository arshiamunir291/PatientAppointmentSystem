using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PatientAppointmentSystem.Entities;

namespace PatientAppointmentSystem.Entity_Configuration
{
    public class AppointmentConfiguration: IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.HasKey(b => b.AppointmentId).HasName("PK_Appoint");
            builder.Property(b => b.Status).HasMaxLength(20);
            builder.Property(b => b.VisitType).HasMaxLength(20);
            builder.Property(b => b.Notes).HasMaxLength(500);
            builder.HasOne(a => a.Patient).WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PatientId);
            builder.HasOne(a => a.Physician).WithMany(p => p.Appointments)
            .HasForeignKey(d => d.PhysicianId);










        }
       

    }
}
