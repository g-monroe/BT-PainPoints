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
using BTSuggestions.Core.Interfaces.Managers;
using BTSuggestions.Core.Interfaces.Engines;

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
        private readonly IPainPointManager _painpointManager;
        private readonly IPainPointEngine _painpointEngine;
        public PainPointController(IPainPointManager painPointManager, IPainPointEngine painPointEngine)
        {
            _painpointManager = painPointManager;
            _painpointEngine = painPointEngine;
        }
        // GET api/painpoint
        [HttpGet]
        public async Task<IEnumerable<PainPoint>> Get()
        {
            return await _painpointManager.GetPainPoints();
        }

        // GET api/painpoint/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PainPoint>> Get(int id)
        {
            return await _painpointEngine.GetPainPoint(id);
        }
        // GET api/painpoint/5/comments
        [HttpGet("{id}/comments")]
        public async Task<ActionResult<IEnumerable<Comment>>> GetComments(int id)
        {
            var result = await _painpointEngine.GetComments(id);
            if (result == null)
            {
                return NotFound();
            }
            return result.ToList();
        }
        // GET api/painpoint/5/user
        [HttpGet("{id}/user")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            return await _painpointEngine.GetUser(id);
        }
        // GET api/painpoint/5/title
        [HttpGet("{id}/title")]
        public async Task<ActionResult<string>> GetTitle(int id)
        {
            return await _painpointEngine.GetTitle(id);
        }
        // GET api/painpoint/5/title
        [HttpGet("{id}/summary")]
        public async Task<ActionResult<string>> GetSummary(int id)
        {
            return await _painpointEngine.GetSummary(id);
        }
        // POST api/painpoint
        [HttpPost]
        public async Task<ActionResult<PainPoint>> PostPainPoint(PainPoint value)
        {
            return await _painpointManager.AddNewPainPoint(value);
        }
        [HttpPost("seed")]
        public void PostSeed()
        {
            _painpointManager.PostSeed();
        }
        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<ActionResult<PainPoint>> PutPainPoint(int id, PainPoint value)
        {
            return await _painpointManager.UpdatePainPoint(id, value);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
            PainPoint result = await _painpointEngine.GetPainPoint(id);
            await _painpointManager.Delete(result);
        }
    }
}
