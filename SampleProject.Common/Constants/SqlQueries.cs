using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.Common.Constants
{
    public static class SqlQueries
    {
        public static string GetAllDoctors = "SELECT * FROM Doctor WITH(NOLOCK)";
        public static string GetDoctorByID = "SELECT * FROM Doctor WITH(NOLOCK) WHERE DoctorId = @Id";
        public static string GetUserByNameAndPassword = "SELECT UserID FROM [User] WITH(NOLOCK) WHERE UserName = @UserName AND Password = @Password";
        public static string GetEmployeeJobByEmployeeIDandJobID = "SELECT COUNT(1) FROM EmployeeJob WHERE UserID = @UserID AND JobID = @JobID";
    }
}
