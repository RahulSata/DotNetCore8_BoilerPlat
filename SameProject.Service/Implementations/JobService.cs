using Microsoft.Extensions.Logging;
using SampleProject.Common.Models.Entities;
using SampleProject.Repository.Implementations;
using SampleProject.Repository.Interfaces;
using SampleProject.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.Service.Implementations
{
    public class JobService : IJobService
    {
        private readonly IJobRepository _jobRepository;
        private readonly ILogger<JobService> _logger;

        public JobService(IJobRepository jobRepository, ILogger<JobService> logger)
        {
            _jobRepository = jobRepository;
            _logger = logger;
        }

        public Task<int> AddJob(Job job) => _jobRepository.AddJob(job);

        public async Task<bool> ApplyToJob(int userId, int jobId)
        {
            var alreadyApplied = await _jobRepository.HasUserApplied(userId, jobId);
            if (alreadyApplied)
                return false;

            await _jobRepository.CreateEmployeeJob(userId, jobId);
            return true;
        }

    }
}