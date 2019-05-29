using BTSuggestions.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BTSuggestions.Core.Interfaces.DataAccessHandlers
{
    public interface ICommentHandler : IBaseHandler<Comment>
    {
        Task<string> GetSatus(int id);
        Task<string> GetText(int id);
        Task<PainPoint> GetPainPoint(int id);
        Task<User> GetUser(int id);
    }
}
