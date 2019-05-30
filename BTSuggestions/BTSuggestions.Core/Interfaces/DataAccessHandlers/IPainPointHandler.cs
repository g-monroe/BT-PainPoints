using BTSuggestions.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BTSuggestions.Core.Interfaces.DataAccessHandlers
{
    public interface IPainPointHandler : IBaseHandler<PainPointEntity>
    {
        Task<IEnumerable<CommentEntity>> GetComments(int id);
        Task<UserEntity> GetUser(int id);
        Task<string> GetTitle(int id);
        Task<string> GetSummary(int id);
        void PostSeed();
    }
}
