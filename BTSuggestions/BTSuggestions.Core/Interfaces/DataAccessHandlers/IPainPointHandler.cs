using BTSuggestions.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BTSuggestions.Core.Interfaces.DataAccessHandlers
{
    public interface IPainPointHandler : IBaseHandler<PainPoint>
    {
        Task<IEnumerable<Comment>> GetComments(int id);
        Task<User> GetUser(int id);
        Task<string> GetTitle(int id);
        Task<string> GetSummary(int id);
        void PostSeed();
    }
}
