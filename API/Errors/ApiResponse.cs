using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string errorMessage = null)
        {
            StatusCode = statusCode;
            ErrorMessage = errorMessage ?? GetDefaultErrorMessageForStatusCode(statusCode);
        }

       
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }

        private string GetDefaultErrorMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "A badrequest, you have made.",
                401 => "Authorized, you are not.",
                404 => "Resource found, it was not.",
                500 => "There is an error in the darkside. Error crates Anger, Anger creates Hate and hate creates career.",
                _ => null
            };
        }

    }
}
