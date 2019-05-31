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

        public async Task<CommentEntity> CreateCommentEntity(int painPointId, int userId, string commentText, string status, DateTime createdOn)
        {
            var comment = new CommentEntity
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

        public async Task<CommentEntity> GetComment(int id)
        {
            var comment = await _commentHandler.GetById(id);
            return comment;
        }

        public async Task<IEnumerable<CommentEntity>> GetComments()
        {
            return await _commentHandler.GetAll();
        }

        public Task<PainPointEntity> GetPainPoint(int id)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetStatus(int id)
        {
            return await _commentHandler.GetStatus(id);
        }

        public async Task<string> GetText(int id)
        {
            return await _commentHandler.GetText(id);
        }

        public async Task<UserEntity> GetUser(int id)
        {
            return await _commentHandler.GetUser(id);
        }

        public async Task<CommentEntity> UpdateComment(CommentEntity comment, string commentText, DateTime createdOn)
        {
            comment.CommentText = commentText;
            comment.CreatedOn = createdOn;
            await _commentHandler.Update(comment);
            return comment;
        }
    }
}
