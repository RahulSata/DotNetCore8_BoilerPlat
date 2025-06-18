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

    public class JobController : ControllerBase
    {
        private readonly IJobService _jobService;
        private readonly IMapper _mapper;

        public JobController(IJobService jobService, IMapper mapper)
        {
            _jobService = jobService;
            _mapper = mapper;
        }

        //[HttpGet("all")]
        //[MapToApiVersion("1.0")]
        //public async Task<BaseAPIResponse<List<DoctorDto>>> GetAll()
        //{
        //    var doctors = await _jobService();
        //    var doctorDtos = _mapper.Map<List<DoctorDto>>(doctors);
        //    return BaseAPIResponse<List<DoctorDto>>.SuccessResponse(doctorDtos);
        //}


        //[HttpGet("{id}")]
        //public async Task<BaseAPIResponse<DoctorDto>> GetById(int id)
        //{
        //    var doctor = await _jobService.GetDoctorByID(id);
        //    var doctorDto = _mapper.Map<DoctorDto>(doctor);
        //    return BaseAPIResponse<DoctorDto>.SuccessResponse(doctorDto);
        //}

        [HttpPost]
        public async Task<BaseAPIResponse<int>> CreateJob(JobDto jobDto)
        {
            var job = _mapper.Map<Job>(jobDto);
            var id = await _jobService.AddJob(job);
            return BaseAPIResponse<int>.SuccessResponse(id);
        }

        [HttpPost("{jobId}/apply")]
        public async Task<BaseAPIResponse<string>> ApplyToJob(int jobId, [FromBody] ApplyJobDto applyJobDto)
        {
            if (jobId <= 0 || applyJobDto.UserId <= 0)
                return BaseAPIResponse<string>.ErrorResponse("Invalid job ID or user ID", HttpStatusCode.BadRequest);

            var result = await _jobService.ApplyToJob(applyJobDto.UserId, jobId);
            if (!result)
                return BaseAPIResponse<string>.ErrorResponse("Application failed or already applied", HttpStatusCode.BadRequest);

            return BaseAPIResponse<string>.SuccessResponse("Applied successfully");
        }
    }
}
