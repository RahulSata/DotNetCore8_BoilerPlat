using SampleProject.Common.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.Repository.Interfaces
{
    public interface ICompanyRepository
    {
        Task<int> AddCompany(Company compay);
    }
}
