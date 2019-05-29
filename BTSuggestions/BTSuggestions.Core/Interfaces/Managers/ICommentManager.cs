using BTSuggestions.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BTSuggestions.Core.Interfaces.Managers
{
    public interface ICommentManager
    {
        Task<IEnumerable<Comment>> GetComments();
        Task<Comment> AddNewComment(int userId, int PainPointId, string commentText, string status, DateTime createdOn);
        Task<Comment> UpdateComment(int commentId, string commentText, DateTime createdOn);
    }
}
