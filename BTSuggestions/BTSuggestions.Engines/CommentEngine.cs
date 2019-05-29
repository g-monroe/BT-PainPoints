using BTSuggestions.Core.Entities;
using BTSuggestions.Core.Interfaces.DataAccessHandlers;
using BTSuggestions.Core.Interfaces.Engines;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BTSuggestions.Engines
{
    public class CommentEngine : ICommentEngine
    {
        private readonly ICommentHandler _commentHandler;
        public CommentEngine(ICommentHandler commentHandler)
        {
            _commentHandler = commentHandler;
        }

        public async Task<Comment> CreateCommentEntity(int painPointId, int userId, string commentText, string status, DateTime createdOn)
        {
            var comment = new Comment
            {
                PainPointId = painPointId,
                UserId = userId,
                CommentText = commentText,
                Status = status,
                CreatedOn = createdOn
            };
            await _commentHandler.Insert(comment);
            await _commentHandler.SaveChanges();

            return comment;
        }

        public async Task<Comment> GetComment(int id)
        {
            var comment = await _commentHandler.GetById(id);
            return comment;
        }

        public async Task<IEnumerable<Comment>> GetComments()
        {
            return await _commentHandler.GetAll();
        }

        public async Task<Comment> UpdateComment(Comment comment, string commentText, DateTime createdOn)
        {
            comment.CommentText = commentText;
            comment.CreatedOn = createdOn;
            await _commentHandler.Update(comment);
            return comment;
        }
    }
}
