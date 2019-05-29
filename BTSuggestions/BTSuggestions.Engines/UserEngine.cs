using BTSuggestions.Core.Entities;
using BTSuggestions.Core.Interfaces.DataAccessHandlers;
using BTSuggestions.Core.Interfaces.Engines;
using System;
using System.Collections.Generic;
using System.Text;

namespace BTSuggestions.Engines
{
    public class UserEngine : IUserEngine
    {
        private readonly IUserHandler _userHandler;
        public UserEngine(IUserHandler userHandler)
        {
            _userHandler = userHandler;
        }

        public User CreateUserEntity(string email, string username, string firstName, string lastName, string password, int privilege)
        {
            var user = new User
            {
                Email = email,
                Username = username,
                Firstname = firstName,
                Lastname = lastName,
                Password = password,
                Privilege = privilege
            };
            _userHandler.Insert(user);
            _userHandler.SaveChanges();

            return user;
        }

        public User GetUser(int id)
        {
            var user = _userHandler.GetById(id);
            return user;
        }

        public IEnumerable<User> GetUsers()
        {
            return _userHandler.GetAll();
        }

        public User UpdateUser(User user, string email, string firstName, string lastName, string password, int privilege)
        {
            user.Email = email;
            user.Firstname = firstName;
            user.Lastname = lastName;
            user.Password = password;
            user.Privilege = privilege;

            return user;
        }
    }
}
