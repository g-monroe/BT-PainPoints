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
using BTSuggestions.Managers.ResponseObjects;

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
        public PainPointController(IPainPointManager painPointManager)
        {
            _painpointManager = painPointManager;
        }
        // GET api/painpoint
        [HttpGet]
        public async Task<PainPointResponseList> Get()
        {
            var pps = await _painpointManager.GetAllIncludes();
            var resp = new PainPointResponseList
            {
                TotalResults = pps.Count(),
                PainPointsList = pps.Select(me => new PainPointResponse()
                {
                    User = me.User,
                    PriorityLevel = me.PriorityLevel,
                    UserId = me.UserId,
                    Type = me.Types,
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
        public async Task<ActionResult<PainPointResponse>> Get(int id)
        {
            var me = await _painpointManager.GetIncludes(id);
            if (me == null)
            {
                return NotFound();
            }
            var resp = new PainPointResponse
            {
                User = me.User,
                PriorityLevel = me.PriorityLevel,
                UserId = me.UserId,
                Type = me.Types,
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
            };
            return resp;
        }
        // GET api/painpoint/priority
        [HttpGet("priority")]
        public async Task<ActionResult<PainPointResponseList>> GetOrderByPriority()
        {
            var results = await _painpointManager.GetOrderByPriority();
            if (results == null)
            {
                return NotFound();
            }
            var resp = new PainPointResponseList
            {
                TotalResults = results.Count(),
                PainPointsList = results.Select(me => new PainPointResponse()
                {
                    User = me.User,
                    PriorityLevel = me.PriorityLevel,
                    UserId = me.UserId,
                    Type = me.Types,
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
        // GET api/painpoint/priority
        [HttpGet("priority/{id}")]
        public async Task<ActionResult<PainPointResponseList>> GetByPriority(int id)
        {
            var result = await _painpointManager.GetByPriority(id);
            if (result == null)
            {
                return NotFound();
            }
            var resp = new PainPointResponseList
            {
                TotalResults = result.Count(),
                PainPointsList = result.Select(me => new PainPointResponse()
                {
                    User = me.User,
                    PriorityLevel = me.PriorityLevel,
                    UserId = me.UserId,
                    Type = me.Types,
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

        //TODO: Remove task to remove warning. Does not need to be async.
        [HttpGet("priority/types/{typeName}")]
        public async Task<ActionResult<PainPointResponseList>> GetOrderByPriorityType(string typeName)
        {
            var result =  _painpointManager.GetOrderByPriorityType(typeName);
            if (result == null)
            {
                return NotFound();
            }
            var resp = new PainPointResponseList
            {
                TotalResults = result.Count(),
                PainPointsList = result.Select(me => new PainPointResponse()
                {
                    User = me.User,
                    PriorityLevel = me.PriorityLevel,
                    UserId = me.UserId,
                    Type = me.Types,
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

        // GET api/painpoint/5/comments
        [HttpGet("{id}/comments")]
        public async Task<ActionResult<CommentResponseList>> GetComments(int id)
        {
            var result = await _painpointManager.GetComments(id);
            if (result == null)
            {
                return NotFound();
            }
            var resp = new CommentResponseList
            {
                TotalResults = result.Count(),
                CommentsList = result.Select(me => new CommentResponse()
                {
                    User = me.User,
                    UserId = me.UserId,
                    CommentId = me.Id,
                    CreatedOn = me.CreatedOn,
                    PainPointId = me.PainPointId,
                    PainPoint = me.PainPoint,
                    CommentText = me.CommentText,
                    Status = me.Status
                }).ToList()
            };
            return resp;
        }
        // GET api/painpoint/5/user
        [HttpGet("{id}/user")]
        public async Task<ActionResult<UserResponse>> GetUser(int id)
        {
            var me = await _painpointManager.GetUser(id);
            if (me == null)
            {
                return NotFound();
            }
            var resp = new UserResponse
            {
                UserId = me.Id,
                Email = me.Email,
                Username = me.Username,
                FirstName = me.Firstname,
                LastName = me.Lastname,
                Password = me.Password,
                Privilege = me.Privilege
            };
            return resp;
        }

        // GET api/painpoint/5/title
        [HttpGet("{id}/title")]
        public async Task<ActionResult<string>> GetTitle(int id)
        {
            return await _painpointManager.GetTitle(id);
        }
        // GET api/painpoint/5/title
        [HttpGet("{id}/summary")]
        public async Task<ActionResult<string>> GetSummary(int id)
        {

            var result = await _painpointManager.GetSummary(id);
            if (result == null)
            {
                return NotFound();
            }
            return result;
        }
        // POST api/painpoint
        [HttpPost]
        public async Task<ActionResult<PainPointEntity>> PostPainPoint(PainPointEntity value)
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
        public async Task<ActionResult<PainPointEntity>> PutPainPoint(int id, PainPointEntity value)
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
            PainPointEntity result = await _painpointManager.GetPainPoint(id);
            if (result == null)
            {
                return NotFound();
            }
            await _painpointManager.Delete(result);
            return Ok();
        }
    }
}
