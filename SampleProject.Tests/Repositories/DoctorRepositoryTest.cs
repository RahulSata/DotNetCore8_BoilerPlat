using Dapper;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using SampleProject.Common.Constants;
using SampleProject.Common.Models.Entities;
using SampleProject.Repository.Context;
using SampleProject.Repository.Implementations;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SampleProject.Tests.Repositories
{
    [TestFixture]
    public class DoctorRepositoryTests : RepositoryTestBase
    {
        private DoctorRepository _repository;
        private Mock<ILogger<DoctorRepository>> _mockLogger;

        [SetUp]
        public void Setup()
        {
            _mockLogger = new Mock<ILogger<DoctorRepository>>();
            _repository = new DoctorRepository(Connection, Context, _mockLogger.Object);
        }

        [Test]
        public async Task GetAllDoctors_ReturnsExpectedDoctors()
        {
            var result = await _repository.GetAllDoctors();
            Assert.That(result.Count(), Is.EqualTo(2));
        }

        [Test]
        public async Task GetDoctorByID_ReturnsExpectedDoctor()
        {
            var result = await _repository.GetDoctorByID(1);
            Assert.IsNotNull(result);
            Assert.That(result.Name, Is.EqualTo("Dr. Rahul"));
        }

        [Test]
        public async Task GetDoctorByID_ReturnsNoDoctor()
        {
            var result = await _repository.GetDoctorByID(3);
            Assert.IsNull(result);
        }
    }

}
