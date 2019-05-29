using BTSuggestions.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BTSuggestions.Core.Interfaces.Engines
{
    public interface IUserEngine
    {
        IEnumerable<User> GetUsers();
        User GetUser(int id);
        User CreateUserEntity(string email, string username, string firstName, string lastName, string password, int privilege);
        User UpdateUser(User user, string email, string username, string firstName, string lastName, string password, int privilege);
    }
}
