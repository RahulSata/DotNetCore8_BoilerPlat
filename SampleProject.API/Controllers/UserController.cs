using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SampleProject.Common.Models.Common;
using SampleProject.Common.Models.DTOs;
using SampleProject.Common.Models.Entities;
using SampleProject.Service.Interfaces;

namespace SampleProject.API.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]

    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService doctorService, IMapper mapper)
        {
            _userService = doctorService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<BaseAPIResponse<int>> Create(UserDto userDto)
        {
            var validUserTypes = new[] { "Employer", "JobSeekers" };

            if (!validUserTypes.Contains(userDto.UserType, StringComparer.OrdinalIgnoreCase))
            {
                return BaseAPIResponse<int>.ErrorResponse("Invalid UserType. Allowed values are 'Employer' or 'JobSeekers'.", System.Net.HttpStatusCode.BadRequest);
            }
            var user = _mapper.Map<User>(userDto);
            var id = await _userService.AddUser(user);
            return BaseAPIResponse<int>.SuccessResponse(id);
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<BaseAPIResponse<int?>> Login([FromBody] LoginRequestDto request)
        {
            var userId = await _userService.Authenticate(request.Username, request.Password);

            if (userId == null)
                return BaseAPIResponse<int?>.ErrorResponse("Invalid Username password", System.Net.HttpStatusCode.Unauthorized);

            return BaseAPIResponse<int?>.SuccessResponse(userId);
        }

    }
}
