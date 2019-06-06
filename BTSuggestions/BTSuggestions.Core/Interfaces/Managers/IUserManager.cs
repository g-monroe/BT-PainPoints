using BTSuggestions.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BTSuggestions.Core.Interfaces.Managers
{
    public interface IUserManager
    {
        Task<IEnumerable<UserEntity>> GetUsers();
        Task<UserEntity> AddNewUser(UserEntity newUSer);
        Task<UserEntity> UpdateUser(int userId, string userEmail, string firstName, string lastName, string password, int privilage);
        Task<UserEntity> GetUser(int id);
        Task<int> GetPrivilege(int id);
        Task<string> GetUsername(int id);
        Task<string> GetEmail(int id);
        Task<string> GetLastname(int id);
        Task<string> GetFirstname(int id);
        Task Delete(UserEntity user);
        IEnumerable<PainPointEntity> GetByStatus(int id, string status);
    }
}
