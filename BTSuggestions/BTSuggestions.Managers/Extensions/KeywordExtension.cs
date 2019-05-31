using BTSuggestions.Core.Entities;
using BTSuggestions.Managers.RequestObjects;
using BTSuggestions.Managers.ResponseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BTSuggestions.Managers.Extensions
{
    public static class KeywordExtension
    {
        public static KeywordResponseList KeywordToListResponse(this IEnumerable<KeywordEntity> me)
        {
            var resp = new KeywordResponseList
            {
                TotalResults = me.Count(),
                KeywordsList = me.Select(x => x.KeywordToListItem()).ToList()
            };
            return resp;
        }
        public static KeywordResponse KeywordToListItem(this KeywordEntity me)
        {
            return new KeywordResponse()
            {
                KeywordId = me.Id,
                PainPoint = me.PainPoint,
                PainPointID = me.PainPointID,
                Score = me.Score,
                TaggedDescription = me.TaggedDescription
            };
        }
        public static KeywordEntity UserToDbItem(this KeywordRequest me, KeywordEntity updating = null)
        {
            if (updating == null)
            {
                updating = new KeywordEntity();
            }
            updating.Id = me.KeywordId;
            updating.PainPoint = me.PainPoint;
            updating.PainPointID = me.PainPointID;
            updating.Score = me.Score;
            updating.TaggedDescription = me.TaggedDescription;
            return updating;
        }
    }
}
