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
    public class UserRepository : IUserRepository
    {
        private readonly IDbConnection _db;
        private readonly AppDbContext _context;
        private readonly ILogger<UserRepository> _logger;
        public UserRepository(IDbConnection db, AppDbContext context, ILogger<UserRepository> logger)
        {
            _db = db;
            _context = context;
            _logger = logger;
        }

        public async Task<int> AddUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user.UserID;
        }

        public async Task<int?> Authenticate(string username, string password)
        {
            return await _db.QueryFirstOrDefaultAsync<int?>(SqlQueries.GetUserByNameAndPassword, new { UserName = username, Password = password });
        }
    }
}
