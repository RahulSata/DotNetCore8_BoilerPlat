using SampleProject.Common.Models.Entities;
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

        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public async Task<IEnumerable<Doctor>> GetAllDoctors()
        {
            return await _doctorRepository.GetAllDoctors();
        }

        public Task<Doctor?> GetDoctorByID(int id) => _doctorRepository.GetDoctorByID(id);

        public Task<int> AddDoctor(Doctor doctor) => _doctorRepository.AddDoctor(doctor);

    }
}
