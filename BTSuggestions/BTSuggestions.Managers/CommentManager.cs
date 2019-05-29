using BTSuggestions.Core.Entities;
using BTSuggestions.Core.Interfaces.Engines;
using BTSuggestions.Core.Interfaces.Managers;
using System;
using System.Collections.Generic;
using System.Text;

namespace BTSuggestions.Managers
{
    public class CommentManager : ICommentManager
    {
        private readonly ICommentEngine _commentEngine;
        public CommentManager(ICommentEngine commentEngine)
        {
            _commentEngine = commentEngine;
        }

        public Comment AddNewComment(int userId, int PainPointId, string commentText, string status, DateTime createdOn)
        {
            return _commentEngine.CreateCommentEntity(PainPointId, userId, commentText, status, createdOn);
        }

        public IEnumerable<Comment> GetComments()
        {
            return _commentEngine.GetComments();
        }

        public Comment UpdateComment(int commentId, string commentText, DateTime createdOn)
        {
            var comment = _commentEngine.GetComment(commentId);
            return _commentEngine.UpdateComment(comment, commentText, createdOn);
        }
    }
}
