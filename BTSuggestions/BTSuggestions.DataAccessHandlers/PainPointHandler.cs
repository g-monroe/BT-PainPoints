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
    public class PainPointHandler : BaseHandler<PainPoint>, IPainPointHandler
    {
     
        public PainPointHandler(BTSuggestionContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Comment>> GetComments(int id)
        {
            var issue = await _context.Comments.Where(s => s.PainPointId == id).ToListAsync();
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

        public async Task<User> GetUser(int id)
        {
            var issue = await GetById(id);
            var user = await _context.Users.FindAsync(issue.UserId);
            if (issue == null || user == null)
            {
                return null;
            }

            return user;
        }

        public void PostSeed()
        {
            var newUser = new User
            {
                Username = "johnwick",
                Firstname = "John",
                Lastname = "Wick",
                Password = "johnwick2019",
                Privilege = 69,
                Email = "johnwickboi@gmail.com"
            };
            var newUser2 = new User
            {
                Username = "robinwick",
                Firstname = "Robin",
                Lastname = "Hick",
                Password = "rawnwick2019",
                Privilege = 67,
                Email = "johnwickman@gmail.com"
            };
            var newUsers = new List<User>() { newUser, newUser2 };
            var newPain = new PainPoint
            {
                Title = "This is test",
                Summary = "This is the summary of the descripted Pain Point.",
                Annontation = "Wow I can't bee-lieve you've done this!",
                Status = "Open",
                User = newUser,
                UserId = newUser.Id,
                CompanyContact = "JohnWick",
                CompanyLocation = "Kansas",
                CompanyName = "BeeKiller",
                IndustryType = "Ninja",
                Type = 3,
                PriorityLevel = 99
            };
            var newPain2 = new PainPoint
            {
                Title = "A new test. This is test",
                Summary = "Wow this is cool. This is the summary of the descripted Pain Point.",
                Annontation = "My manager said Wow I can't bee-lieve you've done this!",
                Status = "Closed",
                User = newUser2,
                UserId = newUser2.Id,
                CompanyContact = "JimmyWick",
                CompanyLocation = "Iowa",
                CompanyName = "FlyLover",
                IndustryType = "Wow'er",
                Type = 2,
                PriorityLevel = 98
            };
            var newPains = new List<PainPoint>() { newPain, newPain2 };

            var newComments = new List<Comment>()
            {
                new Comment
                {
                    User = newUser2,
                    UserId = newUser2.Id,
                    PainPoint = newPain,
                    PainPointId = newPain.Id,
                    CommentText = "Hey I like your bees",
                    Status = "Responded"
                },
            };
            _context.Users.AddRange(newUsers);
            _context.PainPoints.AddRange(newPains);
            _context.Comments.AddRange(newComments);
             _context.SaveChanges();
        }
    }
}

