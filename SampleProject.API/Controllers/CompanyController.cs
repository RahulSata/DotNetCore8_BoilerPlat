using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SampleProject.Common.Models.Common;
using SampleProject.Common.Models.DTOs;
using SampleProject.Common.Models.Entities;
using SampleProject.Service.Interfaces;

namespace SampleProject.API.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyService companyService, IMapper mapper)
        {
            _companyService = companyService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<BaseAPIResponse<int>> Create(CompanyDto companyDto)
        {
            var company = _mapper.Map<Company>(companyDto);
            company.CreatedDate = DateTime.UtcNow;
            company.CreatedBy = companyDto.UserId;

            var id = await _companyService.AddCompany(company);
            return BaseAPIResponse<int>.SuccessResponse(id);
        }
    }
}
