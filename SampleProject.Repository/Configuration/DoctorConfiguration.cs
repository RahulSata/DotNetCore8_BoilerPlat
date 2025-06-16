using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleProject.Common.Models.Entities;

namespace DoctorManagement.Repository.Configurations
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.ToTable("Doctor");

            builder.HasKey(d => d.DoctorId);
            builder.Property(d => d.Name);
            builder.Property(d => d.Specialization);
            builder.Property(d => d.Phone);
            builder.Property(d => d.CreatedDate)
                .HasDefaultValueSql("GETDATE()");
            builder.Property(d => d.UpdatedDate);
        }
    }
}
