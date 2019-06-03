using BTSuggestions.Core.Entities;
using BTSuggestions.Core.Interfaces.DataAccessHandlers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTSuggestions.DataAccessHandlers
{
    public class ContentHandler : BaseHandler<ContentEntity>, IContentHandler
    {
        private readonly new BTSuggestionContext _context;
        public ContentHandler(BTSuggestionContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ContentEntity> GetContent(int id)
        {
            return await _context.Contents.Include(s => s.User).FirstAsync(x => x.Id == id);
        }

        public async Task<string> GetContentById(int id)
        {
            var result = await _context.Contents.FindAsync(id);
            return result.Content;
        }

        public async Task<string> GetContentByUser(int id)
        {
            var result = await _context.Contents.Where(x => x.UserId == id).ToListAsync();
            return result[0].Content; //Return First Object in list, .First isn't async from research.
        }

        public async Task<IEnumerable<ContentEntity>> GetContents()
        {
            return await _context.Contents
                .Include(s => s.User).ToListAsync();
        }

        public async Task<UserEntity> GetUser(int id)
        {
            var result = await _context.Contents.FindAsync(id);
            return result.User;
        }

       
    }
}
