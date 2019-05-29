﻿using BTSuggestions.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BTSuggestions.Core.Interfaces.DataAccessHandlers
{
    public interface IUserHandler : IBaseHandler<User>
    {
        Task<int> GetPrivilege(int id);
        Task<string> GetUsername(int id);
        Task<string> GetEmail(int id);
        Task<string> GetLastname(int id);
        Task<string> GetFirstname(int id);
    }
}
