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

        public async Task<PainPointEntity> AddNewPainPoint(PainPointEntity value)
        {
            return await _painPointEngine.CreatePainPoint(value);
        }

        public async Task<IEnumerable<PainPointEntity>> GetPainPoints()
        {
            return await _painPointEngine.GetPainPoints();
        }

        public async Task<PainPointEntity> UpdatePainPoint(int painPointId, PainPointEntity value)
        {
            var painPoint = await _painPointEngine.GetPainPoint(painPointId);
            return await _painPointEngine.UpdatePainPoint(painPoint, value);
        }
        public void PostSeed()
        {
            _painPointEngine.PostSeed();
        }
        public Task Delete(PainPointEntity value)
        {
            return  _painPointEngine.Delete(value);
        }

        public async Task<IEnumerable<Comment>> GetComments(int id)
        {
            return await _painPointEngine.GetComments(id);
        }

        public async Task<string> GetSummary(int id)
        {
            return await _painPointEngine.GetSummary(id);
        }

        public async Task<string> GetTitle(int id)
        {
            return await _painPointEngine.GetTitle(id);
        }

        public async Task<UserEntity> GetUser(int id)
        {
            return await _painPointEngine.GetUser(id);
        }
        public async Task<PainPointEntity> GetPainPoint(int id)
        {
            var painPoint = await _painPointEngine.GetPainPoint(id);
            return painPoint;
        }

    }
}
