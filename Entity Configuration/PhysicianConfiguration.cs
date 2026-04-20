using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PatientAppointmentSystem.Entities;

namespace PatientAppointmentSystem.Entity_Configuration
{
    public class PhysicianConfiguration : IEntityTypeConfiguration<Physician>
    {
        public void Configure(EntityTypeBuilder<Physician> builder)
        {
            builder.HasKey(e => e.PhysicianId).HasName("PK_Phy");
            builder.Property(e => e.FirstName).HasMaxLength(50);
            builder.Property(e => e.LastName).HasMaxLength(50);
            builder.Property(e => e.Specialization).HasMaxLength(100);
            builder.Property(e => e.ConsultationFee).HasColumnType("decimal(10, 2)");
            builder.HasOne(p => p.Department)
                .WithMany(d => d.Physicians)
                .HasForeignKey(p => p.DepartmentId);

            builder.HasMany(p => p.Appointments)
                .WithOne(a => a.Physician)
                .HasForeignKey(a => a.PhysicianId);
        }
      
            
    
    }
}
