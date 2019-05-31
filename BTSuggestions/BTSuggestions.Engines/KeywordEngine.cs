using BTSuggestions.Core.Entities;
using BTSuggestions.Core.Interfaces.DataAccessHandlers;
using BTSuggestions.Core.Interfaces.Engines;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BTSuggestions.Engines
{
    public class KeywordEngine : IKeywordEngine
    {
        private readonly IKeywordHandler _keywordHandler;
        public KeywordEngine(IKeywordHandler keywordHandler)
        {
            _keywordHandler = keywordHandler;
        }

        public async Task<KeywordEntity> AddNewKeyword(KeywordEntity newKeyword)
        {
            await _keywordHandler.Insert(newKeyword);
            await _keywordHandler.SaveChanges();
            return newKeyword;
        }

        public async Task<KeywordEntity> GetKeywordAsync(int id)
        {
            var key = await _keywordHandler.GetById(id);
            if (key == null)
            {
                return null;
            }
            return key;
        }

        public async Task<IEnumerable<KeywordEntity>> GetKeywords()
        {
            var key = await _keywordHandler.GetAll();
            if (key == null)
            {
                return null;
            }
            return key;
        }

        public async Task<KeywordEntity> UpdateKeyword(int id, KeywordEntity newKeyword)
        {
            KeywordEntity keyword = await _keywordHandler.GetById(id);
            if (keyword == null)
            {
                return null;
            }
            keyword.PainPoint = newKeyword.PainPoint;
            keyword.PainPointID = newKeyword.PainPointID;
            keyword.Score = newKeyword.Score;
            keyword.TaggedDescription = newKeyword.TaggedDescription;
            await _keywordHandler.Update(keyword);
            return keyword;
        }
        public Task Delete(KeywordEntity entity)
        {
            _keywordHandler.Delete(entity);
            return Task.CompletedTask;
        }
    }
}
