using BTSuggestions.Core.Entities;
using BTSuggestions.Core.Interfaces.Engines;
using BTSuggestions.Core.Interfaces.Managers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BTSuggestions.Managers
{
    public class CommentManager : ICommentManager
    {
        private readonly ICommentEngine _commentEngine;
        public CommentManager(ICommentEngine commentEngine)
        {
            _commentEngine = commentEngine;
        }

        public async Task<CommentEntity> AddNewComment(int userId, int PainPointId, string commentText, string status, DateTime createdOn)
        {
            return await _commentEngine.CreateCommentEntity(PainPointId, userId, commentText, status, createdOn);
        }

        public async Task<IEnumerable<CommentEntity>> GetComments()
        {
            return await _commentEngine.GetComments();
        }
        public async Task<CommentEntity> GetComment(int id)
        {
            return await _commentEngine.GetComment(id);
        }
        public async Task<UserEntity> GetUser(int id)
        {
            return await _commentEngine.GetUser(id);
        }
        public async Task<CommentEntity> UpdateComment(int commentId, string commentText, DateTime createdOn)
        {
            var comment = await _commentEngine.GetComment(commentId);
            return await _commentEngine.UpdateComment(comment, commentText, createdOn);
        }

        public async Task<Task> DeleteComent(CommentEntity comment)
        {
            return await _commentEngine.DeleteComent(comment);
        }
    }
}
