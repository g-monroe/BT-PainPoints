using BTSuggestions.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BTSuggestions.Core.Interfaces.Engines
{
    public interface IPainPointEngine
    {
        Task<IEnumerable<PainPoint>> GetPainPoints();
        Task<PainPoint> GetPainPoint(int id);
        Task<PainPoint> CreatePainPoint(PainPoint value);
        Task<PainPoint> UpdatePainPoint(PainPoint painPoint, PainPoint newValue);
        Task<IEnumerable<Comment>> GetComments(int id);
        Task<string> GetSummary(int id);
        Task<string> GetTitle(int id);
        Task<User> GetUser(int id);
        void PostSeed();
        Task Delete(PainPoint entity);
    }
}
