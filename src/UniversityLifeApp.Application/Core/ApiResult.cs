using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace UniversityLifeApp.Application.Core
{
    public class ApiResult<TResponse>
    {
        public TResponse Response { get; set; }
        public Dictionary<string, string> Errors { get; set; }
        public int StatusCode { get; set; }

        public static ApiResult<TResponse> Ok(TResponse response)
        {
            return new ApiResult<TResponse>
            {
                Response = response,
                Errors = null,
                StatusCode = (int)HttpStatusCode.OK
            };
        }
        public static ApiResult<TResponse> ERROR(Dictionary<string, string> errors, HttpStatusCode statusCode)
        {
            return new ApiResult<TResponse>
            {
                Errors = errors,
                Response = default,
                StatusCode = (int)statusCode
            };
        }

        public static ApiResult<TResponse> ERROR(string key, string value)
        {
            return new ApiResult<TResponse>
            {
                Response = default,
                StatusCode = (int)HttpStatusCode.BadRequest,
                Errors = new Dictionary<string, string> { { key, value } },

            };
        }
    }
}
