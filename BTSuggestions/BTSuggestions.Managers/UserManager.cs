using BTSuggestions.Core.Entities;
using BTSuggestions.Core.Interfaces.Engines;
using BTSuggestions.Core.Interfaces.Managers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BTSuggestions.Managers
{
    public class UserManager : IUserManager
    {
        private readonly IUserEngine _userEngine;
        public UserManager(IUserEngine userEngine)
        {
            _userEngine = userEngine;
        }

        public async Task<UserEntity> AddNewUser(UserEntity newUser)
        {
            return await _userEngine.CreateUserEntity(newUser);
        }

        public async Task<UserEntity> GetUser(int id)
        {
            return await _userEngine.GetUser(id);
        }

        public async Task<IEnumerable<UserEntity>> GetUsers()
        {
            return await _userEngine.GetUsers();
        }
        public Task Delete(UserEntity user)
        {
            return _userEngine.Delete(user);
        }
        public async Task<UserEntity> UpdateUser(int userId, string userEmail, string firstName, string lastName, string password, int privilage)
        {
            var user = await _userEngine.GetUser(userId);
            return await _userEngine.UpdateUser(user, userEmail, firstName, lastName, password, privilage);
        }
        public async Task<string> GetEmail(int id)
        {
            return await _userEngine.GetEmail(id);
        }

        public async Task<string> GetFirstname(int id)
        {
            return await _userEngine.GetFirstname(id);
        }

        public async Task<string> GetLastname(int id)
        {
            return await _userEngine.GetLastname(id);
        }

        public async Task<int> GetPrivilege(int id)
        {
            return await _userEngine.GetPrivilege(id);
        }

        public async Task<string> GetUsername(int id)
        {
            return await _userEngine.GetUsername(id);
        }
    }
}
