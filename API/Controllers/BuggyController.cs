﻿using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly StoreContext _context;

        public BuggyController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet("notfound")]
        public ActionResult GetNotFoundError()
        {
            var thing = _context.Products.Find(42);
            if (thing == null)
                return NotFound();
            return Ok();
        }

        [HttpGet("servererror")]

        public ActionResult GetServerError()
        {
            var thing = _context.Products.Find(42);
            var thingtoReturn = thing.ToString();
            return Ok();
            
        }

        [HttpGet("badrequest")]

        public ActionResult GetBadRequestError()
        {
            return BadRequest();
        }

        [HttpGet("badrequest/{id}")]
        public ActionResult GetBadRequestError(int id)
        {
            return Ok();
        }
    }
}
