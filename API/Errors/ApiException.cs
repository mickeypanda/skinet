using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Errors
{
    /// <summary>
    /// This class is being used for the sending the error details as stack trace when we are in the development mode to get the proper idea of the error.
    /// but in the prod env it will send only the error code.
    /// </summary>
    public class ApiException : ApiResponse
    {
        public ApiException(int statusCode, string errorMessage = null, string details = null) : base(statusCode, errorMessage)
        {
            Details = details;
        }

        public string Details { get; set; }
    }
}
