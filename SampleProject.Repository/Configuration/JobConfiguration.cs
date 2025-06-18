using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleProject.Common.Models.Entities;

namespace DoctorManagement.Repository.Configurations
{
    public class JobConfiguration : IEntityTypeConfiguration<Job>
    {
        public void Configure(EntityTypeBuilder<Job> builder)
        {
            builder.ToTable("Job");

            builder.HasKey(j => j.JobID);

            builder.Property(j => j.Title)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(j => j.Description)
                .HasColumnType("VARCHAR(MAX)");

            builder.Property(j => j.CompanyID)
                .IsRequired();

            builder.Property(j => j.CreatedDate)
                .HasDefaultValueSql("GETDATE()");

            builder.Property(j => j.CreatedBy)
                .IsRequired();

            builder.Property(j => j.UpdatedDate)
                .IsRequired(false);

            builder.Property(j => j.UpdatedBy)
                .IsRequired(false);
        }
    }
}
