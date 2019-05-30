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
        Task<PainPointEntity> UpdatePainPoint(int painPointId, PainPointEntity value);
        Task<IEnumerable<CommentEntity>> GetComments(int id);
       Task<PainPointEntity> GetPainPoint(int id);

        Task<string> GetSummary(int id);
        Task<string> GetTitle(int id);
        Task<UserEntity> GetUser(int id);
        void PostSeed();
        Task Delete(PainPointEntity entity);
    }
}
