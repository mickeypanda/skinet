using API.Errors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("errors/{code}")]
    //this class is used for handling the errors if user is trying to hit a controller which is not at all available. This will be redirected here.
    //Setting needs to be done from Startup.cs file as well.
    public class ErrorController : BaseApiController
    {
        public IActionResult Error(int Code)
        {
            return new ObjectResult(new ApiResponse(Code));
        }
    }
}
