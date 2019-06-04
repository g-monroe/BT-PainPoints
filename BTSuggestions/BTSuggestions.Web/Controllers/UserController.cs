using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BTSuggestions.Core.Entities;
using BTSuggestions.Core.Interfaces.Engines;
using BTSuggestions.Core.Interfaces.Managers;
using BTSuggestions.Managers.ResponseObjects;
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

        public UserController(IUserManager manager)
        {
            _manager = manager;
        }
        // GET api/user
        [HttpGet]
        public async Task<ActionResult<UserResponseList>> Get()
        {
            var users = await _manager.GetUsers();
            var resp = new UserResponseList
            {
                TotalResults = users.Count(),
                UsersList = users.Select(me => new UserResponse()
                {
                    UserId = me.Id,
                    Username = me.Username,
                    FirstName = me.Firstname,
                    LastName = me.Lastname,
                    Email = me.Email,
                    Password = me.Password,
                    Privilege = me.Privilege
                }).ToList()
            };

            return resp;
        }

        // GET api/user/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserResponse>> Get(int id)
        {
            var me = await _manager.GetUser(id);
            var resp = new UserResponse
            {
                UserId = me.Id,
                Username = me.Username,
                FirstName = me.Firstname,
                LastName = me.Lastname,
                Email = me.Email,
                Password = me.Password,
                Privilege = me.Privilege
            };
            if (me == null)
            {
                return NotFound();
            }
            return resp;
        }
        // GET api/user/5/firstname
        [HttpGet("{id}/firstname")]
        public async Task<ActionResult<string>> GetFirstname(int id)
        {
            return await _manager.GetFirstname(id);
        }
        // GET api/user/5/lastname
        [HttpGet("{id}/lastname")]
        public async Task<ActionResult<string>> GetLastname(int id)
        {
            var result = await _manager.GetLastname(id);
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
            var result = await _manager.GetEmail(id);
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
            var result = await _manager.GetUsername(id);
            if (result == null)
            {
                return NotFound();
            }
            return result;
        }
        [HttpGet("{id}/admin")]
        public async Task<ActionResult<bool>> GetAdmin(int id)
        {
            var result = await _manager.GetUser(id);
            if (result == null)
            {
                return NotFound();
            }
            if (result.Privilege == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        [HttpGet("{username}")]
        public async Task<ActionResult<UserEntity>> GetUserByUsername(string username)
        {
            var results = await _manager.GetUsers();
            var result = results.FirstOrDefault(x => x.Username == username);
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
            var result = await _manager.GetPrivilege(id);
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
