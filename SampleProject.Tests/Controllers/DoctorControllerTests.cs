using AutoMapper;
using Moq;
using NUnit.Framework;
using SampleProject.API.Controllers;
using SampleProject.Common.Models.DTOs;
using SampleProject.Common.Models.Entities;
using SampleProject.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SampleProject.Tests.Controllers
{
    [TestFixture]
    public class DoctorControllerTests
    {
        private Mock<IDoctorService> _mockDoctorService;
        private IMapper _mapper;
        private DoctorController _controller;

        [SetUp]
        public void SetUp()
        {
            _mockDoctorService = new Mock<IDoctorService>();

            // Setup AutoMapper
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Doctor, DoctorDto>();
                cfg.CreateMap<DoctorDto, Doctor>();
            });

            _mapper = config.CreateMapper();

            _controller = new DoctorController(_mockDoctorService.Object, _mapper);
        }

        [Test]
        public async Task GetAll_ReturnsListOfDoctorDtos()
        {
            // Arrange
            var doctors = new List<Doctor>
            {
                new Doctor { DoctorId = 1, Name = "Dr. Rahul" },
                new Doctor { DoctorId = 2, Name = "Dr. Sata" }
            };

            _mockDoctorService
                .Setup(service => service.GetAllDoctors())
                .ReturnsAsync(doctors);

            // Act
            var result = await _controller.GetAll();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(2, result.Data.Count);
            Assert.AreEqual("Dr. Rahul", result.Data[0].Name);
            Assert.AreEqual("Dr. Sata", result.Data[1].Name);
        }
    }
}
