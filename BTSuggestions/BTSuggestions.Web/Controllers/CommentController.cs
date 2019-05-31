using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BTSuggestions.Core.Entities;
using BTSuggestions.Managers.ResponseObjects;
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
        private readonly Managers.CommentManager _commentManager;

        public CommentController(Managers.CommentManager commentManager)
        {
            _commentManager = commentManager;
        }
        // GET api/comments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommentEntity>>> Get()
        {
            var result = await _commentManager.GetComments();
            if (result == null)
            {
                return NotFound();
            }
            return result.ToList();
        }

        // GET api/comment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CommentEntity>> Get(int id)
        {
            var comment = await _commentManager.GetComment(id);
            if (comment == null)
            {
                return NotFound();
            }
            return comment;
        }
        // GET api/comment/5/user
        [HttpGet("{id}/user")]
        public async Task<ActionResult<UserEntity>> GetUser(int id)
        {
            var user= await _commentManager.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }

            return user;
        }
        // GET api/comment/5/painpoint
        [HttpGet("{id}/painpoint")]
        public async Task<ActionResult<PainPointEntity>> GetPainPoint(int id)
        {
            var painPointComment = await _commentManager.GetComment(id);
            var paintPoint = painPointComment.PainPoint;
            var comment = await _commentManager.GetComment(id);
            if (comment == null || paintPoint == null)
            {
                return NotFound();
            }

            return paintPoint;
        }
        // GET api/comment/5/text
        [HttpGet("{id}/text")]
        public async Task<ActionResult<string>> GetText(int id)
        {
            var comment = await _commentManager.GetComment(id);
            if (comment == null)
            {
                return NotFound();
            }

            return comment.CommentText;
        }
        // GET api/painpoint/5/status
        [HttpGet("{id}/status")]
        public async Task<ActionResult<string>> GetSatus(int id)
        {
            var comment = await _commentManager.GetComment(id);
            if (comment == null)
            {
                return NotFound();
            }

            return comment.Status;
        }
        // POST api/comment
        [HttpPost]
        public async Task<ActionResult<CommentResponse>> PostComment(CommentEntity value)
        {
            var me = await _commentManager.AddNewComment(value.UserId, value.PainPointId, value.CommentText, value.Status, value.CreatedOn);
            var response =  new CommentResponse()
            {
                User = me.User,
                UserId = me.UserId,
                CommentId = me.Id,
                CreatedOn = me.CreatedOn,
                PainPointId = me.PainPointId,
                PainPoint = me.PainPoint,
                CommentText = me.CommentText,
                Status = me.Status
            };
            if (me == null)
            {
                return NotFound();
            }
            return response;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComment(int id, CommentEntity value)
        {
            if (id != value.Id)
            {
                return BadRequest();
            }
            var result = _commentManager.UpdateComment(id, value.CommentText, value.CreatedOn);

            var issue = _commentManager.GetComment(id);
            if (issue == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        //TODO: delete comment
        // DELETE api/comments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var comment = await _commentManager.GetComment(id);
            if (comment == null)
            {
                return NotFound();
            }
            //_commentManager.
            //await _context.SaveChangesAsync();
            return true;
        }
    }
}
