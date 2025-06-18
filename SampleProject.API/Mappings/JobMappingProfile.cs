using SampleProject.Common.Models.DTOs;
using SampleProject.Common.Models.Entities;
using AutoMapper;

namespace SampleProject.API.Mappings
{
    public class CompanyMappingProfile : Profile
    {
        public CompanyMappingProfile()
        {
            CreateMap<CompanyDto, Company>();
        }
    }

}
