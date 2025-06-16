using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.Common.Models.Entities
{
    public class Doctor
    {
        public int DoctorId { get; set; }
        public string Name { get; set; } = "";
        public string Specialization { get; set; } = "";
        public string Phone { get; set; } = "";
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }

}
