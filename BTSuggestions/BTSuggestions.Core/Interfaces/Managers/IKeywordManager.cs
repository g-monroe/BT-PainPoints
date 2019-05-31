using BTSuggestions.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BTSuggestions.Core.Interfaces.Managers
{
    public interface IKeywordManager
    {
        Task<IEnumerable<KeywordEntity>> GetKeywords();
        Task<KeywordEntity> GetKeyword(int id);
        Task<KeywordEntity> AddNewKeyword(KeywordEntity newKeyword);
        Task<KeywordEntity> UpdateKeyword(int id, KeywordEntity newKeyword);
        Task Delete(KeywordEntity keyword);
    }
}
