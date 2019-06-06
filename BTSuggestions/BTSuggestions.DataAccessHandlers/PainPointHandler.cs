using BTSuggestions.Core.Entities;
using BTSuggestions.Core.Interfaces.DataAccessHandlers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BTSuggestions.DataAccessHandlers
{
    public class PainPointHandler : BaseHandler<PainPointEntity>, IPainPointHandler
    {
     
        public PainPointHandler(BTSuggestionContext context) : base(context)
        {
        }

        public async Task<IEnumerable<CommentEntity>> GetComments(int id)
        {
            var issue = await _context.Comments.Where(s => s.PainPointId == id).Include(x =>x.User).ToListAsync();
            if (issue == null)
            {
                return null;
            }
            return issue;
        }

        public async Task<string> GetSummary(int id)
        {
            var issue = await GetById(id);
            if (issue == null)
            {
                return null;
            }

            return issue.Summary;
        }

        public async Task<string> GetTitle(int id)
        {
            var issue = await GetById(id);
            if (issue == null)
            {
                return null;
            }

            return issue.Title;
        }

        public async Task<UserEntity> GetUser(int id)
        {
            var issue = await GetById(id);
            var user = await _context.Users.FindAsync(issue.UserId);
            if (issue == null || user == null)
            {
                return null;
            }

            return user;
        }
        public async Task<IEnumerable<PainPointEntity>> GetAllIncludes()
        {
            
            return await _context.PainPoints
                .Include(s => s.TypeEntities)
                .ThenInclude(x => x.Type)
                .Include(u => u.User).ToListAsync();
        }
        public async Task<PainPointEntity> GetIncludes(int id)
        {
            return  await _context.PainPoints.Include(s => s.TypeEntities).ThenInclude(x => x.Type).FirstAsync(x => x.Id == id);
        }
        public async Task<IEnumerable<PainPointEntity>> GetOrderByPriority()
        {
            return await _context.PainPoints.OrderBy(x => x.PriorityLevel).Include(s => s.TypeEntities).ThenInclude(x => x.Type).ToListAsync();
        }
        public async Task<IEnumerable<PainPointEntity>> GetByPriority(int level)
        {
            return await _context.PainPoints.Where(x => x.PriorityLevel == level).Include(s => s.TypeEntities).ThenInclude(x => x.Type).ToListAsync();
        }
        public IEnumerable<PainPointEntity> GetOrderByPriorityType(string typeName)
        {
            return  _context.PainPoints
                .Include(z => z.TypeEntities)
                .ThenInclude(x => x.Type).ToList()
                .Where(t => t.Types.ToList().Contains(typeName)).ToList();
        }

        public async Task<IEnumerable<PainPointEntity>> GetByType(PainPointTypeEntity type)
        {
            return await _context.PainPoints.Where(pp => pp.TypeEntities.Contains(type)).ToListAsync();
        }

        public async Task<IList<IGrouping<IList<PainPointTypeEntity>, PainPointEntity>>> GetTypeAll()
        {
            return await _context.PainPoints.GroupBy(x => x.TypeEntities).OrderBy(pp => pp.Select(z => z.PriorityLevel)).ToListAsync();
        }
        public void PostSeed()
        {
            IEnumerable<string> types = new string[]{ "Bug"};
            var newUser = new UserEntity
            {
                Username = "johnwick",
                Firstname = "John",
                Lastname = "Wick",
                Password = "johnwick2019",
                Privilege = 69,
                Email = "johnwickboi@gmail.com"
            };
            var newTypes = new List<TypeEntity> {
                new TypeEntity
                {
                    Name = "Bug"
                },
                new TypeEntity
                {
                    Name = "UI"
                },
                new TypeEntity
                {
                    Name = "Billing"
                }
            };
            var newUser2 = new UserEntity
            {
                Username = "robinwick",
                Firstname = "Robin",
                Lastname = "Hick",
                Password = "rawnwick2019",
                Privilege = 67,
                Email = "johnwickman@gmail.com"
            };
            var newUsers = new List<UserEntity>() { newUser, newUser2 };
            var newPain = new PainPointEntity()
            {
                Title = "This is test",
                Summary = "This is the summary of the descripted Pain Point.",
                Annotation = "Wow I can't bee-lieve you've done this!",
                Status = "Open",
                User = newUser,
                UserId = newUser.Id,
                CompanyContact = "JohnWick",
                CompanyLocation = "Kansas",
                CompanyName = "BeeKiller",
                IndustryType = "Ninja",
                PriorityLevel = 99
            };
            var newPain2 = new PainPointEntity()
            {
                Title = "A new test. This is test",
                Summary = "Wow this is cool. This is the summary of the descripted Pain Point.",
                Annotation = "My manager said Wow I can't bee-lieve you've done this!",
                Status = "Closed",
                User = newUser2,
                UserId = newUser2.Id,
                CompanyContact = "JimmyWick",
                CompanyLocation = "Iowa",
                CompanyName = "FlyLover",
                IndustryType = "Wow'er",
                PriorityLevel = 98
            };
            var newPains = new List<PainPointEntity>() { newPain, newPain2 };

            var newComments = new List<CommentEntity>()
            {
                new CommentEntity
                {
                    User = newUser2,
                    UserId = newUser2.Id,
                    PainPoint = newPain,
                    PainPointId = newPain.Id,
                    CommentText = "Hey I like your bees",
                    Status = "Responded"
                },
            };
            var newTest = new List<PainPointTypeEntity>()
            {
                new PainPointTypeEntity
                {
                    PainPoint = newPain,
                    PainPointId = newPain.Id,
                    Type = newTypes[0],
                    TypeId = newTypes[0].Id
                },
            };
            _context.Types.AddRange(newTypes);
            _context.Users.AddRange(newUsers);
            _context.PainPoints.AddRange(newPains);
            _context.Comments.AddRange(newComments);
            _context.PainPointTypes.AddRange(newTest);
            _context.SaveChanges();
        }
    }
}

