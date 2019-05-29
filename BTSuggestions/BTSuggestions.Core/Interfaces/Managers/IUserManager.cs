using BTSuggestions.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BTSuggestions.Core.Interfaces.Managers
{
    public interface IUserManager
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> AddNewUser(User newUSer);
        Task<User> UpdateUser(int userId, string userEmail, string firstName, string lastName, string password, int privilage);
        Task<User> GetUser(int id);
        Task Delete(User user);
    }
}
