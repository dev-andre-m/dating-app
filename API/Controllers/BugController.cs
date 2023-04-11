using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BugController : BaseApiController
    {
        private readonly DataContext _context;

        public BugController(DataContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpGet("auth")]
        public ActionResult<string> GetSecret()
        {
            return "secret text";
        }

        [HttpGet("not-found")]
        public ActionResult<AppUser> GetNotFound()
        {
            var errorObject = _context.Users.Find(-1);
            if (errorObject == null) return NotFound();
            return errorObject;
        }

        [HttpGet("server-error")]
        public ActionResult<string> GetServerError()
        {
            var errorObject = _context.Users.Find(-1);
            var errorObjectToReturn = errorObject.ToString();
            return errorObjectToReturn;
        }

        [HttpGet("bad-request")]
        public ActionResult<string> GetBadRequest()
        {
            return BadRequest("Bad request");
        }


    }
}
