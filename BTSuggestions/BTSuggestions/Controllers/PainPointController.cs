using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BTSuggestions.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BTSuggestions.Core;
using BTSuggestions.DataAccessHandlers;
using BTSuggestions.Core.Interfaces.DataAccessHandlers;

namespace BTSuggestions.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PainPointController : ControllerBase
    {
        /// <summary>
        /// This controller is to interface with React Frontend
        /// to Overall pull the data to the front and displayed 
        /// accordingly. We have PUT, POST, GET, AND DELETE,
        /// Depending on what is passed through to the api will
        /// handle differently.
        /// - Gavin
        /// </summary>
        private readonly IPainPointHandler _painpointHandler;

        public PainPointController(IPainPointHandler painPointHandler)
        {
            _painpointHandler = painPointHandler;
        }
        // GET api/painpoint
        [HttpGet]
        public async Task<IEnumerable<PainPoint>> Get()
        {
            return await _context.PainPoints.ToList();
        }

        // GET api/painpoint/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PainPoint>> Get(int id)
        {
            //var issue = await _context.PainPoints.FindAsync(id);
            //if (issue == null)
            //{
            //    return NotFound();
            //}
            //return issue;
        }
        // GET api/painpoint/5/comments
        [HttpGet("{id}/comments")]
        public async Task<ActionResult<IEnumerable<Comment>>> GetComments(int id)
        {
            IEnumerable<Comment> result = await _painpointHandler.GetComments(id);
            return result;
        }
        // GET api/painpoint/5/user
        [HttpGet("{id}/user")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var issue = await _context.PainPoints.FindAsync(id);
            var user = await _context.Users.FindAsync(issue.UserId);
            if (issue == null || user == null)
            {
                return NotFound();
            }
            
            return user;
        }
        // GET api/painpoint/5/title
        [HttpGet("{id}/title")]
        public async Task<ActionResult<string>> GetTitle(int id)
        {
            var issue = await _context.PainPoints.FindAsync(id);
            if (issue == null)
            {
                return NotFound();
            }

            return issue.Title;
        }
        // GET api/painpoint/5/title
        [HttpGet("{id}/summary")]
        public async Task<ActionResult<string>> GetSummary(int id)
        {
            var issue = await _context.PainPoints.FindAsync(id);
            if (issue == null)
            {
                return NotFound();
            }

            return issue.Summary;
        }
        // POST api/painpoint
        [HttpPost]
        public async Task<ActionResult<int>> PostPainPoint(PainPoint value)
        {
            _context.PainPoints.Add(value);
            var result = await _context.SaveChangesAsync();
            return result;
        }
        [HttpPost("seed")]
        public void PostSeed()
        {
            
        }
        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPainPoint(int id, PainPoint value)
        {
            if (id != value.PainPointId)
            {
                return BadRequest();
            }
            _context.Entry(value).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            } catch(DbUpdateConcurrencyException){
                var issue = _context.PainPoints.FindAsync(id);
                if (issue == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Boolean>> Delete(int id)
        {
            var issue = await _context.PainPoints.FindAsync(id);
            if (issue == null)
            {
                return NotFound();
            }
            _context.PainPoints.Remove(issue);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
