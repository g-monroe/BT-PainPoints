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

        public async Task<Comment> AddNewComment(int userId, int PainPointId, string commentText, string status, DateTime createdOn)
        {
            return await _commentEngine.CreateCommentEntity(PainPointId, userId, commentText, status, createdOn);
        }

        public async Task<IEnumerable<Comment>> GetComments()
        {
            return await _commentEngine.GetComments();
        }

        public async Task<Comment> UpdateComment(int commentId, string commentText, DateTime createdOn)
        {
            var comment = await _commentEngine.GetComment(commentId);
            return await _commentEngine.UpdateComment(comment, commentText, createdOn);
        }

   
    }
}
