using BTSuggestions.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BTSuggestions.Core.Interfaces.Managers
{
    public interface IPainPointManager
    {
        Task<IEnumerable<PainPointEntity>> GetPainPoints();
        Task<PainPointEntity> AddNewPainPoint(PainPointEntity value);
        Task<PainPointEntity[]> AddNewPainPoints(PainPointEntity[] value);
        Task<PainPointEntity> UpdatePainPoint(int painPointId, PainPointEntity value);
        Task<IEnumerable<CommentEntity>> GetComments(int id);
        Task<PainPointEntity> GetPainPoint(int id);
        Task<IEnumerable<PainPointEntity>> GetAllIncludes();
        Task<string> GetSummary(int id);
        Task<string> GetTitle(int id);
        Task<UserEntity> GetUser(int id);
        Task<PainPointEntity> GetIncludes(int id);
        Task<IEnumerable<PainPointEntity>> GetOrderByPriority();
        Task<IEnumerable<PainPointEntity>> GetByPriority(int level);
        IEnumerable<PainPointEntity> GetOrderByPriorityType(string typeName);
        void PostSeed();
        bool DeleteById(PainPointEntity input, int userid);
    }
}
