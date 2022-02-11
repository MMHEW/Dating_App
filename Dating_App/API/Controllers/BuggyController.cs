using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Entities;
using API.Data;

namespace API.Controllers
{
    public class BuggyController: BaseApiController
    {
        private readonly DataContext _context;
        public BuggyController(DataContext context)
        {
            _context = context;

        }

        
        [HttpGet("auth")]
        [Authorize]
        public ActionResult<string> GetSecret()
        {
            return "super secret stuff";
        }

        [HttpGet("not-found")]
        public ActionResult<AppUser> GetNotFound()
        {
            var thing = _context.Users.Find(-1);
            if(thing == null) return NotFound();

            return Ok(thing);
        }

        [HttpGet("server-error")]
        public ActionResult<string> GetServerError()
        {
     
            var thing = _context.Users.Find(-1);

            var thingToReturn = thing.ToString();

            return thingToReturn; 
        
        }

        [HttpGet("bad-request")]
        public ActionResult<string> GetBadRequest()
        {
            // return BadRequest("This could have been something amazing");
            return BadRequest();
        }

    }
}