using BTSuggestions.Core.Entities;
using BTSuggestions.Core.Interfaces.DataAccessHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTSuggestions.DataAccessHandlers
{
    public class UserHandler : BaseHandler<UserEntity>, IUserHandler
    {
        public UserHandler(BTSuggestionContext context) : base(context)
        {
        }

        public async Task<string> GetEmail(int id)
        {
            var user = await GetById(id);
            if (user == null)
            {
                return null;
            }

            return user.Email;
        }

        public async Task<string> GetFirstname(int id)
        {
            var user = await GetById(id);
            if (user == null)
            {
                return null;
            }

            return user.Firstname;
        }

        public async Task<string> GetLastname(int id)
        {
            var user = await GetById(id);
            if (user == null)
            {
                return null;
            }
            return user.Lastname;
        }

        public async Task<int> GetPrivilege(int id)
        {
            var user = await GetById(id);
            if (user == null)
            {
                return -1;
            }
            return user.Privilege;
        }
        public IEnumerable<PainPointEntity> GetByStatus(int id, string status)
        {
            return _context.PainPoints.Where(x => x.Status == status && x.UserId == id).ToList();
        }
        public async Task<string> GetUsername(int id)
        {
            var user = await GetById(id);
            if (user == null)
            {
                return null;
            }
            return user.Username;
        }
    }
}
