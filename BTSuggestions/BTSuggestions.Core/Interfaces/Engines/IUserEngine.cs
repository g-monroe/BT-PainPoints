using BTSuggestions.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BTSuggestions.Core.Interfaces.Engines
{
    public interface IUserEngine
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(int id);
        Task<User> CreateUserEntity(User newUser);
        Task<User> UpdateUser(User user, string email, string firstName, string lastName, string password, int privilege);
        Task<int> GetPrivilege(int id);
        Task<string> GetUsername(int id);
        Task<string> GetEmail(int id);
        Task<string> GetLastname(int id);
        Task<string> GetFirstname(int id);
        Task Delete(User user);
    }
}
