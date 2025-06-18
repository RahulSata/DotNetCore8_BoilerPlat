using SampleProject.Common.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.Service.Interfaces
{
    public interface ICompanyService
    {
        Task<int> AddCompany(Company company);
    }
}
