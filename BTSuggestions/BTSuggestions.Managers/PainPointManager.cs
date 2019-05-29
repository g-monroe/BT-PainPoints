using BTSuggestions.Core.Entities;
using BTSuggestions.Core.Interfaces.Engines;
using BTSuggestions.Core.Interfaces.Managers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BTSuggestions.Managers
{
    public class PainPointManager : IPainPointManager
    {
        private readonly IPainPointEngine _painPointEngine;
        public PainPointManager(IPainPointEngine painPointEngine)
        {
            _painPointEngine = painPointEngine;
        }

        public async Task<PainPoint> AddNewPainPoint(PainPoint value)
        {
            return await _painPointEngine.CreatePainPoint(value);
        }

        public async Task<IEnumerable<PainPoint>> GetPainPoints()
        {
            return await _painPointEngine.GetPainPoints();
        }

        public async Task<PainPoint> UpdatePainPoint(int painPointId, PainPoint value)
        {
            var painPoint = await _painPointEngine.GetPainPoint(painPointId);
            return await _painPointEngine.UpdatePainPoint(painPoint, value);
        }
        public void PostSeed()
        {
            _painPointEngine.PostSeed();
        }
        public Task Delete(PainPoint value)
        {
            return  _painPointEngine.Delete(value);
        }
    }
}
