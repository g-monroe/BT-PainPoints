using BTSuggestions.Core.Entities;
using BTSuggestions.Managers.RequestObjects;
using BTSuggestions.Managers.ResponseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BTSuggestions.Managers.Extensions
{
    public static class ContentExtension
    {
        public static ContentResponseList ContentToListResponse(this IEnumerable<ContentEntity> me)
        {
            var resp = new ContentResponseList
            {
                TotalResults = me.Count(),
                ContentsList = me.Select(x => x.ContentToListItem()).ToList()
            };
            return resp;
        }
        public static ContentResponse ContentToListItem(this ContentEntity me)
        {
            return new ContentResponse()
            {
                ContentId = me.Id,
                Content = me.Content,
                User = me.User,
                UserId = me.UserId
            };
        }
        public static ContentEntity UserToDbItem(this ContentRequest me, ContentEntity updating = null)
        {
            if (updating == null)
            {
                updating = new ContentEntity();
            }
            updating.Id = me.ContentId;
            updating.User = me.User;
            updating.UserId = me.UserId;
            updating.Content = me.Content;
            return updating;
        }
    }
}
