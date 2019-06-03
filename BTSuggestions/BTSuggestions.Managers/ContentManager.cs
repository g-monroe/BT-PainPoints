using BTSuggestions.Core.Entities;
using BTSuggestions.Core.Interfaces.Engines;
using BTSuggestions.Core.Interfaces.Managers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BTSuggestions.Managers
{
    public class ContentManager : IContentManager
    {
        private readonly IContentEngine _contentEngine;
        public ContentManager(IContentEngine contentEngine)
        {
            _contentEngine = contentEngine;
        }

        public async Task<ContentEntity> CreateContent(ContentEntity content)
        {
            return await _contentEngine.CreateContent(content);
        }

        public Task<Task> DeleteContent(ContentEntity content)
        {
            return _contentEngine.DeleteContent(content);
        }

        public async Task<ContentEntity> GetContent(int id)
        {
            return await _contentEngine.GetContent(id);
        }

        public async Task<string> GetContentById(int id)
        {
            return await _contentEngine.GetContentById(id);
        }

        public async Task<string> GetContentByUser(int id)
        {
            return await _contentEngine.GetContentByUser(id);
        }

        public async Task<IEnumerable<ContentEntity>> GetContents()
        {
            return await _contentEngine.GetContents();
        }

        public async Task<UserEntity> GetUser(int id)
        {
            return await _contentEngine.GetUser(id);
        }

        public async Task<ContentEntity> UpdateContent(int id, ContentEntity content)
        {
            return await _contentEngine.UpdateContent(id, content);
        }
    }
}
