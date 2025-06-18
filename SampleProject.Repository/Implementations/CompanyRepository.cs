using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SampleProject.Common.Constants;
using SampleProject.Common.Models.Entities;
using SampleProject.Repository.Context;
using SampleProject.Repository.Interfaces;
using System.Data;


namespace SampleProject.Repository.Implementations
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly IDbConnection _db;
        private readonly AppDbContext _context;
        private readonly ILogger<CompanyRepository> _logger;
        public CompanyRepository(IDbConnection db, AppDbContext context, ILogger<CompanyRepository> logger)
        {
            _db = db;
            _context = context;
            _logger = logger;
        }


        public async Task<int> AddCompany(Company company)
        {
            await _context.companies.AddAsync(company);
            await _context.SaveChangesAsync();

            return company.CompanyID;
        }

    }
}
