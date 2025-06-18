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
        public async Task<BaseAPIResponse<List<DoctorDto>>> GetAll()
        {
            try
            {
                var doctors = await _doctorService.GetAllDoctors();
                var doctorDtos = _mapper.Map<List<DoctorDto>>(doctors);
                return BaseAPIResponse<List<DoctorDto>>.SuccessResponse(doctorDtos);
            }
            catch (Exception ex)
            {
                return BaseAPIResponse<List<DoctorDto>>.ErrorResponse($"An error occurred while fetching doctors: {ex.Message}", HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public async Task<BaseAPIResponse<DoctorDto>> GetById(int id)
        {
            try
            {
                var doctor = await _doctorService.GetDoctorByID(id);
                var doctorDto = _mapper.Map<DoctorDto>(doctor);
                return BaseAPIResponse<DoctorDto>.SuccessResponse(doctorDto);
            }
            catch (Exception ex)
            {
                return BaseAPIResponse<DoctorDto>.ErrorResponse($"An error occurred while fetching doctor by ID: {id} with: {ex.Message}", HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        public async Task<BaseAPIResponse<int>> Create(DoctorDto doctorDto)
        {
            try
            {
                var doctor = _mapper.Map<Doctor>(doctorDto);
                var id = await _doctorService.AddDoctor(doctor);
                return BaseAPIResponse<int>.SuccessResponse(id);
            }
            catch (Exception ex)
            {
                return BaseAPIResponse<int>.ErrorResponse($"An error occurred while creating doctor with Name: {doctorDto.Name} with: {ex.Message}", HttpStatusCode.InternalServerError);
            }
        }
    }
}
