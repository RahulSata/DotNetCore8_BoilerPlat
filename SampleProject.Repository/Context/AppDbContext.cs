using Microsoft.EntityFrameworkCore;
using SampleProject.Common.Models.Entities;
using System.Reflection;


namespace SampleProject.Repository.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Company> companies { get; set; }
        public DbSet<Job> jobs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Type> typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
                         .Where(t => t.GetInterfaces().Any(gi => gi.IsGenericType && gi.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>))).ToList();

            foreach (Type type in typesToRegister)
            {
                dynamic? configurationInstance = Activator.CreateInstance(type);
                modelBuilder.ApplyConfiguration(configurationInstance);
            }
        }
    }

}
