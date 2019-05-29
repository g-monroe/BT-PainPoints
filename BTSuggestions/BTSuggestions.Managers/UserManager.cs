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

        public async Task<User> AddNewUser(User newUser)
        {
            return await _userEngine.CreateUserEntity(newUser);
        }

        public async Task<User> GetUser(int id)
        {
            return await _userEngine.GetUser(id);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _userEngine.GetUsers();
        }
        public Task Delete(User user)
        {
            return _userEngine.Delete(user);
        }
        public async Task<User> UpdateUser(int userId, string userEmail, string username, string firstName, string lastName, string password, int privilage)
        {
            var user = await _userEngine.GetUser(userId);
            return await _userEngine.UpdateUser(user, userEmail, username, firstName, lastName, password, privilage);
        }
    }
}
