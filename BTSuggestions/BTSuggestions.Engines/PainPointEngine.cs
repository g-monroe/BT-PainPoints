using BTSuggestions.Core.Entities;
using BTSuggestions.Core.Interfaces.DataAccessHandlers;
using BTSuggestions.Core.Interfaces.Engines;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BTSuggestions.Engines
{
    public class PainPointEngine : IPainPointEngine
    {
        private readonly IPainPointHandler __painPointHandler;
        public PainPointEngine(IPainPointHandler painPointHandler)
        {
            __painPointHandler = painPointHandler;
        }

        public async Task<PainPoint> CreatePainPoint(PainPoint value)
        {
           await __painPointHandler.Insert(value);
           await __painPointHandler.SaveChanges();

            return value;
        }

        public Task<IEnumerable<Comment>> GetComments(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<PainPoint> GetPainPoint(int id)
        {
            var painPoint = await __painPointHandler.GetById(id);
            return painPoint;
        }

        public async Task<IEnumerable<PainPoint>> GetPainPoints()
        {
            return await __painPointHandler.GetAll();
        }

        public async Task<string> GetSummary(int id)
        {
            return await __painPointHandler.GetSummary(id);
        }

        public async Task<string> GetTitle(int id)
        {
            return await __painPointHandler.GetTitle(id);
        }

        public async Task<User> GetUser(int id)
        {
            return await __painPointHandler.GetUser(id);
        }

        public void PostSeed()
        {
            __painPointHandler.PostSeed();
        }

        public async Task<PainPoint> UpdatePainPoint(PainPoint painPoint, PainPoint newPain)
        {
            PainPoint result = await __painPointHandler.GetById(painPoint.Id);
            result.Title = newPain.Title;
            result.Summary = newPain.Summary;
            result.Annontation = newPain.Annontation;
            result.Status = newPain.Status;
            await __painPointHandler.Update(result);
            return painPoint;
        }
        public Task Delete(PainPoint entity)
        {
             __painPointHandler.Delete(entity);
            return Task.CompletedTask;
        }
    }
}
