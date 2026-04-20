using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PatientAppointmentSystem.Entities;

namespace PatientAppointmentSystem.Entity_Configuration
{
    public class PatientConfiguration:IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {


            builder.HasKey(b => b.PatientId).HasName("PK_Patient");
            builder.Property(b => b.FirstName).HasMaxLength(50);
            builder.Property(b => b.LastName).HasMaxLength(50);
            builder.Property(b => b.Email).HasMaxLength(255).HasDefaultValue("Not Provided");
            builder.Property(b => b.City).HasMaxLength(50);
            builder.Property(b => b.Gender).HasMaxLength(1).IsFixedLength();
            builder.Property(b => b.PhoneNumber).HasMaxLength(15);
            builder.HasMany(p => p.Appointments)
               .WithOne(a => a.Patient)
               .HasForeignKey(a => a.PatientId)
               .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
