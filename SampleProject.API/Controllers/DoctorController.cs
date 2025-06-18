using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SampleProject.Common.Models.Common;
using SampleProject.Common.Models.DTOs;
using SampleProject.Common.Models.Entities;
using SampleProject.Service.Interfaces;
using System.Net;

namespace SampleProject.API.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]

    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;
        private readonly IMapper _mapper;

        public DoctorController(IDoctorService doctorService, IMapper mapper)
        {
            _doctorService = doctorService;
            _mapper = mapper;
        }

        [HttpGet("all")]
        [MapToApiVersion("1.0")]
        public async Task<BaseAPIResponse<List<DoctorDto>>> GetAllV1()
        {
            var doctors = await _doctorService.GetAllDoctors();
            var doctorDtos = _mapper.Map<List<DoctorDto>>(doctors);
            return BaseAPIResponse<List<DoctorDto>>.SuccessResponse(doctorDtos);
        }

        [HttpGet("all")]
        [MapToApiVersion("2.0")]
        public async Task<BaseAPIResponse<List<DoctorDto>>> GetAllV2()
        {
            var doctors = await _doctorService.GetAllDoctors();
            var doctorDtos = _mapper.Map<List<DoctorDto>>(doctors);
            return BaseAPIResponse<List<DoctorDto>>.SuccessResponse(doctorDtos);
        }

        [HttpGet("{id}")]
        public async Task<BaseAPIResponse<DoctorDto>> GetById(int id)
        {
            var doctor = await _doctorService.GetDoctorByID(id);
            var doctorDto = _mapper.Map<DoctorDto>(doctor);
            return BaseAPIResponse<DoctorDto>.SuccessResponse(doctorDto);
        }

        [HttpPost]
        public async Task<BaseAPIResponse<int>> Create(DoctorDto doctorDto)
        {
            var doctor = _mapper.Map<Doctor>(doctorDto);
            var id = await _doctorService.AddDoctor(doctor);
            return BaseAPIResponse<int>.SuccessResponse(id);
        }
    }
}
