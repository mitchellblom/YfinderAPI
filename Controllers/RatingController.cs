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
    public class RatingController : Controller
    {

        private YFinderContext _context;
        public RatingController(YFinderContext ctx)
        {
            _context = ctx;
        }

        // GET all Ratings from rating table
        [HttpGet]
        public IActionResult Get(string active)
        {
            IQueryable<object> ratings = from rating in _context.Rating select rating;

            if (ratings == null)
            {
                return NotFound();
            } 

                return Ok(ratings);
        }

        //GET one rating from rating table
        [HttpGet("{id}", Name = "GetRating")]
        public IActionResult Get([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Rating rating = _context.Rating.Single(m => m.RatingId == id);

                if (rating == null)
                {
                    return NotFound();
                }
                
                return Ok(rating);
            }
            catch (System.InvalidOperationException ex)
            {
                return NotFound();
            }
        }

        // POST rating values to the rating table
        [HttpPost]
        public IActionResult Post([FromBody] Rating rating)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Rating.Add(rating);
            
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (RatingExists(rating.RatingId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetRating", new { id = rating.RatingId }, rating);
        }

    // Checks if the Rating has been created or not
    private bool RatingExists(int ratingId)
    {
      throw new NotImplementedException();
    }

    // PUT edited values on existing rating
    [HttpPut("{id}")]
         public IActionResult Put(int id, [FromBody] Rating rating)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rating.RatingId)
            {
                return BadRequest();
            }

            _context.Entry(rating).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RatingExists(id))
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

        // Delete ratings... needs limitation to delete only one's own.
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Rating rating = _context.Rating.Single(r => r.RatingId == id);
            if (rating == null)
            {
                return NotFound();
            }

            _context.Rating.Remove(rating);
            _context.SaveChanges();

            return Ok(rating);
        }

    }
}