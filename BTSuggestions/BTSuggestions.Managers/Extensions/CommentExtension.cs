using BTSuggestions.Core.Entities;
using BTSuggestions.Managers.RequestObjects;
using BTSuggestions.Managers.ResponseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BTSuggestions.Managers.Extensions
{
    public static class CommentExtension
    {
        public static CommentResponseList CommentToListResponse(this IEnumerable<CommentEntity> me)
        {
            var resp = new CommentResponseList
            {
                TotalResults = me.Count(),
                CommentsList = me.Select(x => x.CommentToListItem()).ToList()
            };
            return resp;
        }
        public static CommentResponse CommentToListItem(this CommentEntity me)
        {
            return new CommentResponse()
            {
                User = me.User,
                UserId = me.UserId,
                CommentId = me.Id,
                CreatedOn = me.CreatedOn,
                PainPointId = me.PainPointId,
                PainPoint = me.PainPoint,
                CommentText = me.CommentText,
                Status = me.Status
            };
        }
        public static CommentEntity CommentToDbItem(this CommentRequest me, CommentEntity updating = null)
        {
            if (updating == null)
            {
                updating = new CommentEntity();
            }
            updating.User = me.User;
            updating.Id = me.CommentId;
            updating.CreatedOn= me.CreatedOn;
            updating.PainPointId = me.PainPointId;
            updating.PainPoint = me.PainPoint;
            updating.CommentText = me.CommentText;
            updating.Status = me.Status;
            return updating;
        }
    }
}
