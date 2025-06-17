using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SampleProject.Common.Constants;
using SampleProject.Common.Models.Entities;
using SampleProject.Repository.Context;
using SampleProject.Repository.Interfaces;
using System.Data;


namespace SampleProject.Repository.Implementations
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly IDbConnection _db;
        private readonly AppDbContext _context;
        private readonly ILogger<DoctorRepository> _logger;
        public DoctorRepository(IDbConnection db, AppDbContext context, ILogger<DoctorRepository> logger)
        {
            _db = db;
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<Doctor>> GetAllDoctors()
        {
            _logger.LogInformation($"Fetching Doctors from the database at {DateTime.UtcNow}");
            return await _db.QueryAsync<Doctor>(SqlQueries.GetAllDoctors);
        }

        public async Task<Doctor?> GetDoctorByID(int id)
        {
            return await _db.QueryFirstOrDefaultAsync<Doctor>(SqlQueries.GetDoctorByID, new { Id = id });
        }

        public async Task<int> AddDoctor(Doctor doctor)
        {
            await _context.Doctors.AddAsync(doctor);
            await _context.SaveChangesAsync();

            return doctor.DoctorId;
        }

    }
}
