using BTSuggestions.Core.Entities;
using BTSuggestions.Core.Interfaces.DataAccessHandlers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BTSuggestions.DataAccessHandlers
{
    public class UserHandler : BaseHandler<User>, IUserHandler
    {
        private new BTSuggestionContext _context;
        public UserHandler(BTSuggestionContext context) : base(context)
        {
            _context = context;
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
