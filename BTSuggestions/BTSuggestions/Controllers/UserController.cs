﻿using System;
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
        private readonly Managers.UserManager _manager;
        private readonly Engines.UserEngine _engine;

        public UserController(Managers.UserManager manager, Engines.UserEngine engine)
        {
            _manager = manager;
            _engine = engine;
        }
        // GET api/user
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
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
        public async Task<ActionResult<User>> Get(int id)
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
            return await _engine.GetLastname(id);
        }
        // GET api/user/5/email
        [HttpGet("{id}/email")]
        public async Task<ActionResult<string>> GetEmail(int id)
        {
            return await _engine.GetEmail(id);
        }
        // GET api/user/5/username
        [HttpGet("{id}/username")]
        public async Task<ActionResult<string>> GetUsername(int id)
        {
            return await _engine.GetUsername(id);
        }
        // GET api/user/5/privilege
        [HttpGet("{id}/privilege")]
        public async Task<ActionResult<int>> GetPrivilege(int id)
        {
            return await _engine.GetPrivilege(id);
        }
        // POST api/user
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User value)
        {
            return await _manager.AddNewUser(value);
        }

        // PUT api/user/5
        [HttpPut("{id}")]
        public async Task<ActionResult<User>> PutUser(int id, User value)
        {
            if (id != value.UserId)
            {
                return BadRequest();
            }
            User result = await _manager.UpdateUser(id, value.Email, value.Username, value.Firstname, value.Lastname, value.Password, value.Privilege);
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
