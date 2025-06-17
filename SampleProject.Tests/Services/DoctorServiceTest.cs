using Moq;
using NUnit.Framework;
using Microsoft.Extensions.Logging;
using SampleProject.Service.Implementations;
using SampleProject.Repository.Interfaces;
using SampleProject.Common.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace SampleProject.Tests.Services
{
    [TestFixture]
    public class DoctorServiceTests
    {
        private Mock<IDoctorRepository> _mockDoctorRepo;
        private Mock<ILogger<DoctorService>> _mockLogger;
        private DoctorService _doctorService;

        [SetUp]
        public void SetUp()
        {
            _mockDoctorRepo = new Mock<IDoctorRepository>();
            _mockLogger = new Mock<ILogger<DoctorService>>();
            _doctorService = new DoctorService(_mockDoctorRepo.Object, _mockLogger.Object);
        }

        [Test]
        public async Task GetAllDoctors_ReturnsDoctorsFromRepository()
        {
            // Arrange
            var fakeDoctors = new List<Doctor>
            {
                new Doctor { DoctorId = 1, Name = "Dr. Rahul" },
                new Doctor { DoctorId = 2, Name = "Dr. Sata" }
            };

            _mockDoctorRepo.Setup(repo => repo.GetAllDoctors()).ReturnsAsync(fakeDoctors);

            // Act
            var result = await _doctorService.GetAllDoctors();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("Dr. Rahul", result.First().Name);

            _mockLogger.Verify(
                x => x.Log(
                    LogLevel.Information,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("Fetching Doctors")),
                    It.IsAny<Exception>(),
                    It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
                Times.Once);
        }
    }
}
