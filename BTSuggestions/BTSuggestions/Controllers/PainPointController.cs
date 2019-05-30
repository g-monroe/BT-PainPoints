﻿using System;
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
        public async Task<Managers.ResponseObjects.PainPointResponseList> Get()
        {
            var pps = await _painpointManager.GetPainPoints();
            var resp = new Managers.ResponseObjects.PainPointResponseList
            {
                TotalResults = pps.Count(),
                PainPointsList = pps.Select(me => new Managers.ResponseObjects.PainPointResponse()
                {
                    User = me.User,
                    PriorityLevel = me.PriorityLevel,
                    UserId = me.UserId,
                    Type = me.Type,
                    Annotation = me.Annotation,
                    ComapnyLocation = me.CompanyLocation,
                    CompanyContact = me.CompanyContact,
                    CompanyName = me.CompanyName,
                    Title = me.Title,
                    PainPointId = me.Id,
                    CreatedOn = me.CreatedOn.ToString(),
                    Summary = me.Summary,
                    IndustryType = me.IndustryType,
                    Status = me.Status
                }).ToList()
            };

            return resp;
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

            var result = await _painpointEngine.GetSummary(id);
            if (result == null)
            {
                return NotFound();
            }
            return result;
        }
        // POST api/painpoint
        [HttpPost]
        public async Task<ActionResult<PainPoint>> PostPainPoint(PainPoint value)
        {

            var result = await _painpointManager.AddNewPainPoint(value);
            if (result == null)
            {
                return NotFound();
            }
            return result;
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
            if (id != value.Id)
            {
                return NotFound();
            }
            var result = await _painpointManager.UpdatePainPoint(id, value);
            if (result == null)
            {
                return NotFound();
            }
            return result;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            PainPoint result = await _painpointEngine.GetPainPoint(id);
            if (result == null)
            {
                return NotFound();
            }
            await _painpointManager.Delete(result);
            return Ok();
        }
    }
}
