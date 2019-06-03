using BTSuggestions.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BTSuggestions.Core.Interfaces.Managers
{
    public interface ICommentManager
    {
        Task<IEnumerable<CommentEntity>> GetComments();
        Task<CommentEntity> GetComment(int id);
        Task<CommentEntity> AddNewComment(int userId, int PainPointId, string commentText, string status, DateTime createdOn);
        Task<CommentEntity> UpdateComment(int commentId, string commentText, DateTime createdOn);
        Task<UserEntity> GetUser(int id);
        Task<Task> DeleteComent(CommentEntity comment);
    }
}
