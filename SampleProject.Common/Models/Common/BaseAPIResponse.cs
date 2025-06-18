using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.Common.Models.Common
{
    public class BaseAPIResponse<T>
    {
        public bool Success { get; set; } = true;
        public T Data { get; set; }
        public string Error { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        public static BaseAPIResponse<T> SuccessResponse(T data) =>
            new BaseAPIResponse<T> { Data = data, StatusCode = HttpStatusCode.OK };

        public static BaseAPIResponse<T> ErrorResponse(string error, HttpStatusCode StatusCode) =>
            new BaseAPIResponse<T> { Success = false, Error = error };
    }
}
