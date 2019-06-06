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

        public async Task<PainPointEntity> CreatePainPoint(PainPointEntity value)
        {
            var user = await __painPointHandler.GetUser(value.UserId);
            value.User.Lastname = user.Lastname;
           await __painPointHandler.Insert(value);
           await __painPointHandler.SaveChanges();

            return value;
        }
        public async Task<PainPointEntity[]> CreatePainPoints(PainPointEntity[] value)
        {
            foreach (PainPointEntity x in value)
            {
                await __painPointHandler.Insert(x);
            }
            await __painPointHandler.SaveChanges();

            return value;
        }
        public async Task<IEnumerable<CommentEntity>> GetComments(int id)
        {
            var result = await __painPointHandler.GetComments(id);
            return result;
        }

        public async Task<PainPointEntity> GetPainPoint(int id)
        {
            var painPoint = await __painPointHandler.GetById(id);
            return painPoint;
        }

        public async Task<IEnumerable<PainPointEntity>> GetPainPoints()
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

        public async Task<UserEntity> GetUser(int id)
        {
            return await __painPointHandler.GetUser(id);
        }

        public void PostSeed()
        {
            __painPointHandler.PostSeed();
        }
        public async Task<IEnumerable<PainPointEntity>> GetAllIncludes()
        {
            return await __painPointHandler.GetAllIncludes();
        }
        public async Task<PainPointEntity> UpdatePainPoint(PainPointEntity painPoint, PainPointEntity newPain)
        {
            PainPointEntity result = await __painPointHandler.GetById(painPoint.Id);
            result.Title = newPain.Title;
            result.Summary = newPain.Summary;
            result.Annotation = newPain.Annotation;
            result.Status = newPain.Status;
            await __painPointHandler.Update(result);
            return painPoint;
        }
        public Task Delete(PainPointEntity entity)
        {
             __painPointHandler.Delete(entity);
            return Task.CompletedTask;
        }
        public async Task<PainPointEntity> GetIncludes(int id)
        {
            return await __painPointHandler.GetIncludes(id);
        }
        public async Task<IEnumerable<PainPointEntity>> GetOrderByPriority()
        {
            return await __painPointHandler.GetOrderByPriority();
        }
        public async Task<IEnumerable<PainPointEntity>> GetByPriority(int level)
        {
            return await __painPointHandler.GetByPriority(level);
        }
        public IEnumerable<PainPointEntity> GetOrderByPriorityType(string typeName)
        {
            return __painPointHandler.GetOrderByPriorityType(typeName);
        }
    }
}
