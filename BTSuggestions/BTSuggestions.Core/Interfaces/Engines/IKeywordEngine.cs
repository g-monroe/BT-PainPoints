using BTSuggestions.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BTSuggestions.Core.Interfaces.Engines
{
    public interface IKeywordEngine
    {
        Task<KeywordEntity> AddNewKeyword(KeywordEntity newKeyword);
        Task<KeywordEntity> GetKeywordAsync(int id);
        Task<IEnumerable<KeywordEntity>> GetKeywords();
        Task<KeywordEntity> UpdateKeyword(int id, KeywordEntity newKeyword);
        Task Delete(KeywordEntity entity);
    }
}
