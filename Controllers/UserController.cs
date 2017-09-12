using System;
using System.Collections.Generic;
using System.Linq;
using YFinder.Data;
using YFinder.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Cors;

namespace YFinder.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowWhiteListOrigins")]
    public class UserController : Controller
    {

        private YFinderContext _context;
        public UserController(YFinderContext ctx)
        {
            _context = ctx;
        }

        // GET all Users from user table
        [HttpGet]
        public IActionResult Get(string active)
        {
            IQueryable<object> users = from user in _context.User select user;

            if (users == null)
            {
                return NotFound();
            } 

                return Ok(users);
        }

        //GET one user from user table
        [HttpGet("{id}", Name = "GetUser")]
        public IActionResult Get([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                User user = _context.User.Single(m => m.UserId == id);

                if (user == null)
                {
                    return NotFound();
                }
                
                return Ok(user);
            }
            catch (System.InvalidOperationException ex)
            {
                return NotFound();
            }
        }

        // POST user values to the user table
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.User.Add(user);
            
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (UserExists(user.UserId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetUser", new { id = user.UserId }, user);
        }

    // Checks if the User has been created or not
    private bool UserExists(int userId)
    {
      throw new NotImplementedException();
    }

    // PUT edited values on existing user
    [HttpPut("{id}")]
         public IActionResult Put(int id, [FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.UserId)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return new StatusCodeResult(StatusCodes.Status204NoContent);
        }

        // Delete users... needs limitation to delete only one's own.
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            User user = _context.User.Single(r => r.UserId == id);
            if (user == null)
            {
                return NotFound();
            }

            _context.User.Remove(user);
            _context.SaveChanges();

            return Ok(user);
        }

    }
}