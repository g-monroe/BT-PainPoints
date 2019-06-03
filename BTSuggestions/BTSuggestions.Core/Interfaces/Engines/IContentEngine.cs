using BTSuggestions.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BTSuggestions.Core.Interfaces.Engines
{
    public interface IContentEngine
    {
        Task<string> GetContentById(int id);
        Task<string> GetContentByUser(int id);
        Task<UserEntity> GetUser(int id);
        Task<IEnumerable<ContentEntity>> GetContents();
        Task<ContentEntity> GetContent(int id);
        Task<ContentEntity> UpdateContent(int id, ContentEntity content);
        Task<ContentEntity> CreateContent(ContentEntity content);
        Task<Task> DeleteContent(ContentEntity content);
    }
}
