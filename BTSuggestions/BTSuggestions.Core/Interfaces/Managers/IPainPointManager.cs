using BTSuggestions.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BTSuggestions.Core.Interfaces.Managers
{
    public interface IPainPointManager
    {
        Task<IEnumerable<PainPoint>> GetPainPoints();
        Task<PainPoint> AddNewPainPoint(PainPoint value);
        Task<PainPoint> UpdatePainPoint(int painPointId, PainPoint value);
        void PostSeed();
        Task Delete(PainPoint entity);
    }
}
