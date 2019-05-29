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
    public class UserController : ControllerBase
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

        public UserController(DataAccessHandlers.BTSuggestionContext context)
        {
            _context = context;
        }
        // GET api/user
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            return _context.Users.ToList();
        }

        // GET api/user/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }
        // GET api/user/5/firstname
        [HttpGet("{id}/firstname")]
        public async Task<ActionResult<string>> GetFirstname(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null || user == null)
            {
                return NotFound();
            }
            
            return user.Firstname;
        }
        // GET api/user/5/lastname
        [HttpGet("{id}/lastname")]
        public async Task<ActionResult<string>> GetLastname(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null || user == null)
            {
                return NotFound();
            }

            return user.Lastname;
        }
        // GET api/user/5/email
        [HttpGet("{id}/email")]
        public async Task<ActionResult<string>> GetEmail(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null || user == null)
            {
                return NotFound();
            }

            return user.Email;
        }
        // GET api/user/5/username
        [HttpGet("{id}/username")]
        public async Task<ActionResult<string>> GetUsername(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null || user == null)
            {
                return NotFound();
            }

            return user.Username;
        }
        // GET api/user/5/privilege
        [HttpGet("{id}/privilege")]
        public async Task<ActionResult<int>> GetPrivilege(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null || user == null)
            {
                return NotFound();
            }

            return user.Privilege;
        }
        // POST api/user
        [HttpPost]
        public async Task<ActionResult<int>> PostUser(User value)
        {
            _context.Users.Add(value);
            var result = await _context.SaveChangesAsync();
            return result;
        }

        // PUT api/user/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User value)
        {
            if (id != value.UserId)
            {
                return BadRequest();
            }
            _context.Entry(value).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            } catch(DbUpdateConcurrencyException){
                var issue = _context.Users.FindAsync(id);
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

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Boolean>> Delete(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
