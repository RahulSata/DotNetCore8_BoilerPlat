

using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SampleProject.Common.Constants;
using SampleProject.Common.Models.Entities;
using SampleProject.Repository.Context;
using SampleProject.Repository.Interfaces;
using System.Data;
using System.Numerics;


namespace SampleProject.Repository.Implementations
{
    public class JobRepository : IJobRepository
    {
        private readonly IDbConnection _db;
        private readonly AppDbContext _context;
        private readonly ILogger<JobRepository> _logger;
        public JobRepository(IDbConnection db, AppDbContext context, ILogger<JobRepository> logger)
        {
            _db = db;
            _context = context;
            _logger = logger;
        }


        public async Task<int> AddJob(Job job)
        {
            await _context.jobs.AddAsync(job);
            await _context.SaveChangesAsync();

            return job.CompanyID;
        }

        public async Task<bool> HasUserApplied(int userId, int jobId)
        {
            var count = await _db.ExecuteScalarAsync<int>(SqlQueries.GetEmployeeJobByEmployeeIDandJobID, new { UserID = userId, JobID = jobId });
            return count > 0;
        }

        public async Task CreateEmployeeJob(int userId, int jobId)
        {
            
        }
    }
}
