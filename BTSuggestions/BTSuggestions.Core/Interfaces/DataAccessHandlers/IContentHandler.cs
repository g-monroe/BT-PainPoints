using BTSuggestions.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BTSuggestions.Core.Interfaces.DataAccessHandlers
{
    public interface IContentHandler : IBaseHandler<ContentEntity>
    {
        Task<string> GetContentById(int id);
        Task<string> GetContentByUser(int id);
        Task<UserEntity> GetUser(int id);
        Task<IEnumerable<ContentEntity>> GetContents();
        Task<ContentEntity> GetContent(int id);
    }
}
