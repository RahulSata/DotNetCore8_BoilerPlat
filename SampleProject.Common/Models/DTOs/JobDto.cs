using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.Common.Models.DTOs
{
    public class JobDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int CompanyID { get; set; }
        public int CreatedBy { get; set; }
    }
}
