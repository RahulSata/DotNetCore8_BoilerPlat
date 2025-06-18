using SampleProject.Common.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.Repository.Interfaces
{
    public interface IJobRepository
    {
        Task<int> AddJob(Job job);
        Task<bool> HasUserApplied(int userId, int jobId);
        Task CreateEmployeeJob(int userId, int jobId);
    }
}
