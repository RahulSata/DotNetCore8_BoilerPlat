using SampleProject.Common.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.Service.Interfaces
{
    public interface IUserService
    {
        Task<int> AddUser(User user);
        Task<int?> Authenticate(string username, string password);
    }
}
