using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BTSuggestions.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BTSuggestions.Core;
using BTSuggestions.DataAccessHandlers;
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
        private readonly BTSuggestionContext _context;

        public PainPointController(BTSuggestionContext context)
        {
            _context = context;
        }
        // GET api/painpoint
        [HttpGet]
        public ActionResult<IEnumerable<PainPoint>> Get()
        {
            return _context.PainPoints.ToList();
        }

        // GET api/painpoint/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PainPoint>> Get(int id)
        {
            var issue = await _context.PainPoints.FindAsync(id);
            if (issue == null)
            {
                return NotFound();
            }
            return issue;
        }
        // GET api/painpoint/5/comments
        [HttpGet("{id}/comments")]
        public async Task<ActionResult<IEnumerable<Comment>>> GetComments(int id)
        {
            var issue = await _context.Comments.Where(s => s.PainPointId == id).ToListAsync();
            if (issue == null)
            {
                return NotFound();
            }
            return issue;
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
            var newUser = new User
            {
                Username = "johnwick",
                Firstname = "John",
                Lastname = "Wick",
                Password = "johnwick2019",
                Privilege = 69,
                Email = "johnwickboi@gmail.com"
            };
            var newPain = new PainPoint
            {
                Title = "This is test",
                Summary = "This is the summary of the descripted Pain Point.",
                Annontation = "Wow I can't bee-lieve you've done this!",
                Status = "Open",
                User = newUser,
                UserId = newUser.Id,
                CompanyContact = "JohnWick",
                CompanyLocation = "Kansas",
                CompanyName = "BeeKiller",
                IndustryType = "Ninja",
                Type = 3,
                PriorityLevel = 99
            };
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
