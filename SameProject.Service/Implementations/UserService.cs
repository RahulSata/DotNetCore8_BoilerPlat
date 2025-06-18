
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

namespace SampleProject.Service.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<UserService> _logger;

        public UserService(IUserRepository userRepository, ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        public Task<int> AddUser(User user) => _userRepository.AddUser(user);

        public Task<int?> Authenticate(string username, string password)
        {
            return _userRepository.Authenticate(username, password);
        }
    }
}
