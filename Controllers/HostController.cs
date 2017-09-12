using System;
using System.Collections.Generic;
using System.Linq;
using YFinderAPI.Data;
using YFinderAPI.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Cors;

namespace YFinderAPI.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowWhiteListOrigins")]
    public class HostController : Controller
    {

        private YFinderContext _context;
        public HostController(YFinderContext ctx)
        {
            _context = ctx;
        }

        // GET all Hosts from host table
        [HttpGet]
        public IActionResult Get(string active)
        {
            IQueryable<object> hosts = from host in _context.Host select host;

            if (hosts == null)
            {
                return NotFound();
            } 

                return Ok(hosts);
        }

        //GET one host from host table
        [HttpGet("{id}", Name = "GetHost")]
        public IActionResult Get([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Host host = _context.Host.Single(m => m.HostId == id);

                if (host == null)
                {
                    return NotFound();
                }
                
                return Ok(host);
            }
            catch (System.InvalidOperationException ex)
            {
                return NotFound();
            }
        }

        // POST host values to the host table
        [HttpPost]
        public IActionResult Post([FromBody] Host host)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Host.Add(host);
            
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (HostExists(host.HostId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetHost", new { id = host.HostId }, host);
        }

    // Checks if the Host has been created or not
    private bool HostExists(int hostId)
    {
      throw new NotImplementedException();
    }

    // PUT edited values on existing host
    [HttpPut("{id}")]
         public IActionResult Put(int id, [FromBody] Host host)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != host.HostId)
            {
                return BadRequest();
            }

            _context.Entry(host).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HostExists(id))
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

    // Delete feature may be in version 2. This may end up as an "active" vs "inactive" host for search results.

    }
}