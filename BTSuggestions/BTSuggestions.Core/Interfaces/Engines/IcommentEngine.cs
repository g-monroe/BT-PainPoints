using BTSuggestions.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BTSuggestions.Core.Interfaces.Engines
{
    public interface ICommentEngine
    {
        Task<IEnumerable<CommentEntity>> GetComments();
        Task<CommentEntity> GetComment(int id);
        Task<CommentEntity> CreateCommentEntity(int painPointId, int userId, string commentText, string status, DateTime createdOn);
        Task<CommentEntity> UpdateComment(CommentEntity comment, string commentText, DateTime createdOn);
        Task<UserEntity> GetUser(int id);
        Task<PainPointEntity> GetPainPoint(int id);
        Task<string> GetStatus(int id);
        Task<string> GetText(int id);
       Task<Task> DeleteComent(CommentEntity comment);
    }
}
