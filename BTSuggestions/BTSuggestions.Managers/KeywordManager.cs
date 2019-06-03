using BTSuggestions.Core.Entities;
using BTSuggestions.Core.Interfaces.Engines;
using BTSuggestions.Core.Interfaces.Managers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BTSuggestions.Managers
{
    public class KeywordManager : IKeywordManager
    {
        private readonly IKeywordEngine _keywordEngine;
        public KeywordManager(IKeywordEngine keywordEngine)
        {
            _keywordEngine = keywordEngine;
        }
        private string findScore()
        {
            return "";
        }
        public async Task<KeywordEntity> AddNewKeyword(KeywordEntity newKeyword)
        {
            return await _keywordEngine.AddNewKeyword(newKeyword);
        }

        public  Task Delete(KeywordEntity keyword)
        {
            _keywordEngine.Delete(keyword);
            return Task.CompletedTask;
        }

        public async Task<KeywordEntity> GetKeyword(int id)
        {
            return await _keywordEngine.GetKeywordAsync(id);
        }

        public async Task<IEnumerable<KeywordEntity>> GetKeywords()
        {
            return await _keywordEngine.GetKeywords();
        }

        public async Task<KeywordEntity> UpdateKeyword(int id, KeywordEntity newKeyword)
        {
            return await _keywordEngine.UpdateKeyword(id, newKeyword);
        }
    }
}
