using BTSuggestions.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BTSuggestions.Core.Interfaces.Engines
{
    public interface IPainPointEngine
    {
        Task<IEnumerable<PainPointEntity>> GetPainPoints();
        Task<PainPointEntity> GetPainPoint(int id);
        Task<PainPointEntity> CreatePainPoint(PainPointEntity value);
        Task<PainPointEntity> UpdatePainPoint(PainPointEntity painPoint, PainPointEntity newValue);
        Task<IEnumerable<CommentEntity>> GetComments(int id);
        Task<string> GetSummary(int id);
        Task<string> GetTitle(int id);
        Task<UserEntity> GetUser(int id);
        void PostSeed();
        Task Delete(PainPointEntity entity);
    }
}
