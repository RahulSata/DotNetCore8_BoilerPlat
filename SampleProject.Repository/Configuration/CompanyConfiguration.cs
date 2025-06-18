using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleProject.Common.Models.Entities;

namespace DoctorManagement.Repository.Configurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Company");

            builder.HasKey(c => c.CompanyID);

            builder.Property(c => c.CompanyName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.CreatedDate)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");

            builder.Property(c => c.CreatedBy)
                .IsRequired();

            builder.Property(c => c.UpdatedDate)
                .IsRequired(false);

            builder.Property(c => c.UpdatedBy)
                .IsRequired(false);
        }
    }

}
