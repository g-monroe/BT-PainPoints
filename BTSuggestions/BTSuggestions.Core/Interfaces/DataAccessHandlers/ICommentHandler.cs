using BTSuggestions.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BTSuggestions.Core.Interfaces.DataAccessHandlers
{
    public interface ICommentHandler : IBaseHandler<CommentEntity>
    {
        Task<string> GetSatus(int id);
        Task<string> GetText(int id);
        Task<PainPointEntity> GetPainPoint(int id);
        Task<UserEntity> GetUser(int id);
    }
}
