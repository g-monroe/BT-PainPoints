using BTSuggestions.Core.Entities;
using BTSuggestions.Core.Interfaces.DataAccessHandlers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BTSuggestions.DataAccessHandlers
{
    public class CommentHandler : BaseHandler<Comment>, ICommentHandler
    {
        private readonly new BTSuggestionContext _context;
        public CommentHandler(BTSuggestionContext context) : base(context)
        {
            _context = context;
        }

        public async Task<PainPoint> GetPainPoint(int id)
        {
            var comment = await GetById(id);
            var pain = await _context.PainPoints.FindAsync(comment.PainPointId);
            if (comment == null || pain == null)
            {
                return null;
            }

            return pain;
        }

        public async Task<string> GetSatus(int id)
        {
            var comment = await GetById(id);
            if (comment == null)
            {
                return null;
            }

            return comment.Status;
        }

        public async Task<string> GetText(int id)
        {
            var comment = await GetById(id);
            if (comment == null)
            {
                return null;
            }

            return comment.CommentText;
        }

        public async Task<User> GetUser(int id)
        {
            var comment = await GetById(id);
            var user = await _context.Users.FindAsync(comment.UserId);
            if (comment == null || user == null)
            {
                return null;
            }

            return user;
        }
    }
}
