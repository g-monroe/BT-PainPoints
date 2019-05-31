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
        Task<IEnumerable<PainPointEntity>> GetAllIncludes();
        Task<PainPointEntity> GetIncludes(int id);
        Task<IEnumerable<PainPointEntity>> GetOrderByPriority();
        Task<IEnumerable<PainPointEntity>> GetByPriority(int level);
        IEnumerable<PainPointEntity> GetOrderByPriorityType(string typeName);
        void PostSeed();
    }
}
