using BTSuggestions.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BTSuggestions.Core.Interfaces.Managers
{
    public interface ICommentManager
    {
        IEnumerable<Comment> GetComments();
        Comment AddNewComment(int userId, int PainPointId, string commentText, string status, DateTime createdOn);
        Comment UpdateComment(int commentId, string commentText, DateTime createdOn);
    }
}
