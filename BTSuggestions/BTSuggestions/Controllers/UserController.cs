using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BTSuggestions.Core.Entities;
using BTSuggestions.Core.Interfaces.Engines;
using BTSuggestions.Core.Interfaces.Managers;
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
        private readonly IUserManager _manager;
        private readonly IUserEngine _engine;

        public UserController(IUserManager manager, IUserEngine engine)
        {
            _manager = manager;
            _engine = engine;
        }
        // GET api/user
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserEntity>>> Get()
        {
            var result = await _manager.GetUsers();
            if (result == null)
            {
                return NotFound();
            }
            return result.ToList();
        }

        // GET api/user/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserEntity>> Get(int id)
        {
            var result = await _manager.GetUser(id);
            if (result == null)
            {
                return NotFound();
            }
            return result;
        }
        // GET api/user/5/firstname
        [HttpGet("{id}/firstname")]
        public async Task<ActionResult<string>> GetFirstname(int id)
        {
            return await _engine.GetFirstname(id);
        }
        // GET api/user/5/lastname
        [HttpGet("{id}/lastname")]
        public async Task<ActionResult<string>> GetLastname(int id)
        {
            var result = await _engine.GetLastname(id);
            if (result == null)
            {
                return NotFound();
            }
            return result;
        }
        // GET api/user/5/email
        [HttpGet("{id}/email")]
        public async Task<ActionResult<string>> GetEmail(int id)
        {
            var result = await _engine.GetEmail(id);
            if (result == null)
            {
                return NotFound();
            }
            return result;
        }
        // GET api/user/5/username
        [HttpGet("{id}/username")]
        public async Task<ActionResult<string>> GetUsername(int id)
        {
            var result = await _engine.GetUsername(id);
            if (result == null)
            {
                return NotFound();
            }
            return result;
        }
        // GET api/user/5/privilege
        [HttpGet("{id}/privilege")]
        public async Task<ActionResult<int>> GetPrivilege(int id)
        {
            var result = await _engine.GetPrivilege(id);
            return result;
        }
        // POST api/user
        [HttpPost]
        public async Task<ActionResult<UserEntity>> PostUser(UserEntity value)
        {
            var result = await _manager.AddNewUser(value);
            if (result == null)
            {
                return NotFound();
            }
            return result;
        }

        // PUT api/user/5
        [HttpPut("{id}")]
        public async Task<ActionResult<UserEntity>> PutUser(int id, UserEntity value)
        {
            if (id != value.Id)
            {
                return BadRequest();
            }
            UserEntity result = await _manager.UpdateUser(id, value.Email, value.Firstname, value.Lastname, value.Password, value.Privilege);
            return result;
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Task>> Delete(int id)
        {
            var result = await _manager.GetUser(id);
            if (result == null)
            {
                return NotFound();
            }
            var re = _manager.Delete(result);
            return re;
        }
    }
}
