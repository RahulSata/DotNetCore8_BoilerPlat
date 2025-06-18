using SampleProject.Common.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<int> AddUser(User doctor);
        Task<int?> Authenticate(string username, string password);
    }
}
