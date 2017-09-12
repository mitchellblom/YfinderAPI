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
    public class DescriptorController : Controller
    {

        private YFinderContext _context;
        public DescriptorController(YFinderContext ctx)
        {
            _context = ctx;
        }

        // GET all Descriptors from descriptor table
        [HttpGet]
        public IActionResult Get(string active)
        {
            IQueryable<object> descriptors = from descriptor in _context.Descriptor select descriptor;

            if (descriptors == null)
            {
                return NotFound();
            } 

                return Ok(descriptors);
        }

        //GET one descriptor from descriptor table
        [HttpGet("{id}", Name = "GetDescriptor")]
        public IActionResult Get([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Descriptor descriptor = _context.Descriptor.Single(m => m.DescriptorId == id);

                if (descriptor == null)
                {
                    return NotFound();
                }
                
                return Ok(descriptor);
            }
            catch (System.InvalidOperationException ex)
            {
                return NotFound();
            }
        }

        // POST descriptor values to the descriptor table
        [HttpPost]
        public IActionResult Post([FromBody] Descriptor descriptor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Descriptor.Add(descriptor);
            
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DescriptorExists(descriptor.DescriptorId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetDescriptor", new { id = descriptor.DescriptorId }, descriptor);
        }

    // Checks if the Descriptor has been created or not
    private bool DescriptorExists(int descriptorId)
    {
      throw new NotImplementedException();
    }

    // PUT edited values on existing descriptor
    [HttpPut("{id}")]
         public IActionResult Put(int id, [FromBody] Descriptor descriptor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != descriptor.DescriptorId)
            {
                return BadRequest();
            }

            _context.Entry(descriptor).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DescriptorExists(id))
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

    // No Delete necessary for Descriptors; users will not be deleting them.

    }
}