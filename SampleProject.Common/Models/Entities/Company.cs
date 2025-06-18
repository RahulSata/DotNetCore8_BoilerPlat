using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.Common.Models.Entities
{
    public class Company
    {
        public int CompanyID { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
    }

}
