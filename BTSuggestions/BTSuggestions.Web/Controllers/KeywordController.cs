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
    [Produces("application/json")]
    public class KeywordController : ControllerBase
    {
        /// <summary>
        /// This controller is to interface with React Frontend
        /// to Overall pull the data to the front and displayed 
        /// accordingly. We have PUT, POST, GET, AND DELETE,
        /// Depending on what is passed through to the api will
        /// handle differently.
        /// - Gavin
        /// </summary>
        private readonly IKeywordManager _manager;

        public KeywordController(IKeywordManager manager)
        {
            _manager = manager;
        }
        // GET api/user
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KeywordEntity>>> Get()
        {
            var result = await _manager.GetKeywords();
            if (result == null)
            {
                return NotFound();
            }
            return result.ToList();
        }

        // GET api/user/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KeywordEntity>> Get(int id)
        {
            var result = await _manager.GetKeyword(id);
            if (result == null)
            {
                return NotFound();
            }
            return result;
        }
      
        // POST api/user
        [HttpPost]
        public async Task<ActionResult<KeywordEntity>> PostUser(KeywordEntity value)
        {
            var result = await _manager.AddNewKeyword(value);
            if (result == null)
            {
                return NotFound();
            }
            return result;
        }

        // PUT api/user/5
        [HttpPut("{id}")]
        public async Task<ActionResult<KeywordEntity>> PutUser(int id, KeywordEntity value)
        {
            if (id != value.Id)
            {
                return BadRequest();
            }
            KeywordEntity result = await _manager.UpdateKeyword(id, value);
            return result;
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Task>> Delete(int id)
        {
            var result = await _manager.GetKeyword(id);
            if (result == null)
            {
                return NotFound();
            }
            var re = _manager.Delete(result);
            return re;
        }
    }
}
