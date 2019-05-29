using BTSuggestions.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BTSuggestions.Core.Interfaces.Managers
{
    public interface IUserManager
    {
        IEnumerable<User> GetUsers();
        User AddNewUser(string userEmail, string username, string firstName, string lastName, string password, int privilage);
        User UpdateUser(int userId, string userEmail, string username, string firstName, string lastName, string password, int privilage);
    }
}
