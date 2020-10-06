using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Errors
{
    /// <summary>
    /// This class will be used for handling the validation errors(400) for the service requests.
    /// The IEnumerable property will be set from Startup.cs class.
    /// </summary>
    public class ApiValidationErrorResponse : ApiResponse
    {
        public ApiValidationErrorResponse() : base(400)
        {
        }

        public IEnumerable<string> Errors { get; set; }
    }
}
