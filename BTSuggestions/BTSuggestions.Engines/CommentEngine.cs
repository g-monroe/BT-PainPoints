using BTSuggestions.Core.Entities;
using BTSuggestions.Core.Interfaces.DataAccessHandlers;
using BTSuggestions.Core.Interfaces.Engines;
using System;
using System.Collections.Generic;
using System.Text;

namespace BTSuggestions.Engines
{
    public class CommentEngine : ICommentEngine
    {
        private readonly ICommentHandler _commentHandler;
        public CommentEngine(ICommentHandler commentHandler)
        {
            _commentHandler = commentHandler;
        }

        public Comment CreateCommentEntity(int painPointId, int userId, string commentText, string status, DateTime createdOn)
        {
            var comment = new Comment
            {
                PainPointId = painPointId,
                UserId = userId,
                CommentText = commentText,
                Status = status,
                CreatedOn = createdOn
            };
            _commentHandler.Insert(comment);
            _commentHandler.SaveChanges();

            return comment;
        }

        public Comment GetComment(int id)
        {
            var comment = _commentHandler.GetById(id);
            return comment;
        }

        public IEnumerable<Comment> GetComments()
        {
            return _commentHandler.GetAll();
        }

        public Comment UpdateComment(Comment comment, string commentText, DateTime createdOn)
        {
            comment.CommentText = commentText;
            comment.CreatedOn = createdOn;

            return comment;
        }
    }
}
