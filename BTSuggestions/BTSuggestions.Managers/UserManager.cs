using BTSuggestions.Core.Entities;
using BTSuggestions.Core.Interfaces.Engines;
using BTSuggestions.Core.Interfaces.Managers;
using System;
using System.Collections.Generic;
using System.Text;

namespace BTSuggestions.Managers
{
    public class UserManager : IUserManager
    {
        private readonly IUserEngine _userEngine;
        public UserManager(IUserEngine userEngine)
        {
            _userEngine = userEngine;
        }

        public User AddNewUser(string userEmail, string username, string firstName, string lastName, string password, int privilage)
        {
            return _userEngine.CreateUserEntity(userEmail, username, firstName, lastName, password, privilage);
        }

        public IEnumerable<User> GetUsers()
        {
            return _userEngine.GetUsers();
        }

        public User UpdateUser(int userId, string userEmail, string username, string firstName, string lastName, string password, int privilage)
        {
            var user = _userEngine.GetUser(userId);
            return _userEngine.UpdateUser(user, userEmail, username, firstName, lastName, password, privilage);
        }
    }
}
