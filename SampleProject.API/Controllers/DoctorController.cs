using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SampleProject.Common.Models.DTOs;
using SampleProject.Common.Models.Entities;
using SampleProject.Service.Interfaces;

namespace SampleProject.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;
        private readonly IMapper _mapper;

        public DoctorController(IDoctorService doctorService, IMapper mapper)
        {
            _doctorService = doctorService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<List<DoctorDto>> GetAll()
        {
            var doctors = await _doctorService.GetAllDoctors();
            return _mapper.Map<List<DoctorDto>>(doctors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var doctor = await _doctorService.GetDoctorByID(id);
            return doctor == null ? NotFound() : Ok(_mapper.Map<DoctorDto>(doctor));
        }

        [HttpPost]
        public async Task<IActionResult> Create(DoctorDto doctorDto)
        {
            var doctor = _mapper.Map<Doctor>(doctorDto);
            var id = await _doctorService.AddDoctor(doctor);
            return CreatedAtAction(nameof(GetById), new { id }, doctor);
        }
    }
}
