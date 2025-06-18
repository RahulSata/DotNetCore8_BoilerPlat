using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.Common.Models.DTOs
{
    public class CompanyDto
    {
        public string CompanyName { get; set; } = string.Empty;
        public int UserId { get; set; }  // CreatedBy
    }

}
