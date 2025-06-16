using SampleProject.Common.Models.DTOs;
using SampleProject.Common.Models.Entities;
using AutoMapper;

namespace SampleProject.API.Mappings
{
    public class DoctorProfileMappings : Profile
    {
        public DoctorProfileMappings()
        {
            CreateMap<DoctorDto, Doctor>().ReverseMap();
        }
    }
}
