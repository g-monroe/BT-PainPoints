using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BTSuggestions.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BTSuggestions.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        /// <summary>
        /// This controller is to interface with React Frontend
        /// to Overall pull the data to the front and displayed 
        /// accordingly. We have PUT, POST, GET, AND DELETE,
        /// Depending on what is passed through to the api will
        /// handle differently.
        /// - Gavin
        /// </summary>
        private readonly DataAccessHandlers.BTSuggestionContext _context;

        public CommentController(DataAccessHandlers.BTSuggestionContext context)
        {
            _context = context;
        }
        // GET api/comments
        [HttpGet]
        public ActionResult<IEnumerable<Comment>> Get()
        {
            return _context.Comments.ToList();
        }

        // GET api/comment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Comment>> Get(int id)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }
            return comment;
        }
        // GET api/comment/5/user
        [HttpGet("{id}/user")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var comment = await _context.Comments.FindAsync(id);
            var user = await _context.Users.FindAsync(comment.UserId);
            if (comment == null || user == null)
            {
                return NotFound();
            }
            
            return user;
        }
        // GET api/comment/5/painpoint
        [HttpGet("{id}/painpoint")]
        public async Task<ActionResult<PainPoint>> GetPainPoint(int id)
        {
            var comment = await _context.Comments.FindAsync(id);
            var pain = await _context.PainPoints.FindAsync(comment.PainPointId);
            if (comment == null || pain == null)
            {
                return NotFound();
            }

            return pain;
        }
        // GET api/comment/5/text
        [HttpGet("{id}/text")]
        public async Task<ActionResult<string>> GetText(int id)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }

            return comment.CommentText;
        }
        // GET api/painpoint/5/title
        [HttpGet("{id}/status")]
        public async Task<ActionResult<string>> GetSatus(int id)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }

            return comment.Status;
        }
        // POST api/comment
        [HttpPost]
        public async Task<ActionResult<int>> PostComment(Comment value)
        {
            _context.Comments.Add(value);
            var result = await _context.SaveChangesAsync();
            return result;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComment(int id, Comment value)
        {
            if (id != value.Id)
            {
                return BadRequest();
            }
            _context.Entry(value).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            } catch(DbUpdateConcurrencyException){
                var issue = _context.Comments.FindAsync(id);
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

        // DELETE api/comments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Boolean>> Delete(int id)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
