using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PatientAppointmentSystem.Entities;

namespace PatientAppointmentSystem.Entity_Configuration
{
    public class DepartmentConfiguration: IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(b => b.DepartmentId).HasName("PK_Depart");

            builder.HasIndex(b => b.DepartmentName).HasDatabaseName ("UC_Depart").IsUnique();

            builder.Property(b => b.DepartmentName).HasMaxLength(100);

        }
  
    }
}
