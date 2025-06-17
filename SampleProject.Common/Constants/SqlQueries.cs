using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.Common.Constants
{
    public static class SqlQueries
    {
        public const string GetAllDoctors = "SELECT * FROM Doctor WITH(NOLOCK)";
        public const string GetDoctorByID = "SELECT * FROM Doctor WITH(NOLOCK) WHERE DoctorId = @Id";
    }
}
