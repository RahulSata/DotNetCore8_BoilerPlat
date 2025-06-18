using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.Common.Models.Entities
{
    public class Job
    {
        public int JobID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CompanyID { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
    }

}
