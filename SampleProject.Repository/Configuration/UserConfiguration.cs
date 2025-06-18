using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleProject.Common.Models.Entities;

namespace DoctorManagement.Repository.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.HasKey(u => u.UserID);

            builder.Property(u => u.Username)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(u => u.Password)
                   .IsRequired()
                   .HasMaxLength(25);

            builder.Property(u => u.UserType)
                   .IsRequired()
                   .HasMaxLength(10);

            builder.Property(u => u.CreatedDate)
                   .HasDefaultValueSql("GETDATE()");

            builder.Property(u => u.UpdatedDate);
        }
    }
}
