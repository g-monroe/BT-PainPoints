using BTSuggestions.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BTSuggestions.Core.Interfaces.Engines
{
    public interface ICommentEngine
    {
        IEnumerable<Comment> GetComments();
        Comment GetComment(int id);
        Comment CreateCommentEntity(int painPointId, int userId, string commentText, string status, DateTime createdOn);
        Comment UpdateComment(Comment comment, string commentText, DateTime createdOn);
        // Comment DeleteComent(Comment comment);
    }
}
