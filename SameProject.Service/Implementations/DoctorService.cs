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
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly ILogger<DoctorService> _logger;

        public DoctorService(IDoctorRepository doctorRepository, ILogger<DoctorService> logger)
        {
            _doctorRepository = doctorRepository;
            _logger = logger;
        }

        public async Task<IEnumerable<Doctor>> GetAllDoctors()
        {
            _logger.LogInformation($"Fetching Doctors from the repository method at {DateTime.UtcNow}");
            return await _doctorRepository.GetAllDoctors();
        }

        public Task<Doctor?> GetDoctorByID(int id) => _doctorRepository.GetDoctorByID(id);

        public Task<int> AddDoctor(Doctor doctor) => _doctorRepository.AddDoctor(doctor);

    }
}
