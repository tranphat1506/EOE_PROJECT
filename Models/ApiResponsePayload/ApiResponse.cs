using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E2E_APPLICATION.Models.ApiResponsePayload
{
    public class ApiResponse<TPayload>
    {
        public int HttpCode { get; set; }
        public string Message { get; set; }
        public TPayload? Payload { get; set; }

        public ApiResponse(int statusCode, string message, TPayload payload)
        {
            HttpCode = statusCode;
            Message = message;
            Payload = payload;
        }

        public ApiResponse<T>? ToType<T>()
        {
            if (this is ApiResponse<T> res)
            {
                return res;
            }
            return null;
        }
    }
}
