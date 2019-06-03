using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BTSuggestions.Core.Entities;
using BTSuggestions.Core.Interfaces.Managers;
using BTSuggestions.Managers.ResponseObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BTSuggestions.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentController : ControllerBase
    {
        private readonly IContentManager _contentManager;

        public  ContentController(IContentManager contentManager)
        {
            _contentManager = contentManager;
        }
        // GET api/Content
        [HttpGet]
        public async Task<ActionResult<ContentResponseList>> Get()
        {
            var Contents = await _contentManager.GetContents();
            var resp = new ContentResponseList
            {
                TotalResults = Contents.Count(),
                ContentsList = Contents.Select(me => new ContentResponse()
                {
                    ContentId = me.Id,
                    Content = me.Content,
                    User = me.User,
                    UserId = me.UserId
                }).ToList()
            };

            return resp;
        }

        // GET api/Content/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContentResponse>> Get(int id)
        {
            var me = await _contentManager.GetContent(id);
            var resp = new ContentResponse
            {
                ContentId = me.Id,
                Content = me.Content,
                User = me.User,
                UserId = me.UserId
            };
            if (me == null)
            {
                return NotFound();
            }
            return resp;
        }
        // GET api/Content/5/User
        [HttpGet("{id}/User")]
        public async Task<ActionResult<UserEntity>> GetUser(int id)
        {
            return await _contentManager.GetUser(id);
        }
        // GET api/Content/5/content
        [HttpGet("{id}/content")]
        public async Task<ActionResult<string>> GetContent(int id)
        {
            var result = await _contentManager.GetContent(id);
            if (result == null)
            {
                return NotFound();
            }
            return result.Content;
        }
        // GET api/Content/User/5
        [HttpGet("user/{id}")]
        public async Task<ActionResult<string>> GetContentByUser(int id)
        {
            var result = await _contentManager.GetContentByUser(id);
            if (result == null)
            {
                return NotFound();
            }
            return result;
        }
        // POST api/Content
        [HttpPost]
        public async Task<ActionResult<ContentEntity>> PostContent(ContentEntity value)
        {
            var result = await _contentManager.CreateContent(value);
            if (result == null)
            {
                return NotFound();
            }
            return result;
        }

        // PUT api/Content/5
        [HttpPut("{id}")]
        public async Task<ActionResult<ContentEntity>> PutContent(int id, ContentEntity value)
        {
            if (id != value.Id)
            {
                return BadRequest();
            }
            ContentEntity result = await _contentManager.UpdateContent(id, value);
            return result;
        }

        // DELETE api/Contents/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Task>> Delete(int id)
        {
            var result = await _contentManager.GetContent(id);
            if (result == null)
            {
                return NotFound();
            }
            var re = _contentManager.DeleteContent(result);
            return re;
        }
    }
}