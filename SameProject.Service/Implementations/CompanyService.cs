using Microsoft.Extensions.Logging;
using SampleProject.Common.Models.Entities;
using SampleProject.Repository.Implementations;
using SampleProject.Repository.Interfaces;
using SampleProject.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SampleProject.Service.Implementations
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly ILogger<CompanyService> _logger;

        public CompanyService(ICompanyRepository companyRepository, ILogger<CompanyService> logger)
        {
            _companyRepository = companyRepository;
            _logger = logger;
        }

        public Task<int> AddCompany(Company user) => _companyRepository.AddCompany(user);

    }
}
