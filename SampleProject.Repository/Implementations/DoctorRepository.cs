using SampleProject.Common.Models.Entities;
using System.Data;
using Dapper;
using SampleProject.Repository.Interfaces;
using SampleProject.Common.Constants;
using Microsoft.EntityFrameworkCore;
using SampleProject.Repository.Context;


namespace SampleProject.Repository.Implementations
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly IDbConnection _db;
        private readonly AppDbContext _context;

        public DoctorRepository(IDbConnection db, AppDbContext context)
        {
            _db = db;
            _context = context;
        }

        public async Task<IEnumerable<Doctor>> GetAllDoctors()
        {
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
