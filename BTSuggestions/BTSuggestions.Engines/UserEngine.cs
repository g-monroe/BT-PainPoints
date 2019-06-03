using BTSuggestions.Core.Entities;
using BTSuggestions.Core.Interfaces.DataAccessHandlers;
using BTSuggestions.Core.Interfaces.Engines;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BTSuggestions.Engines
{
    public class UserEngine : IUserEngine
    {
        private readonly IUserHandler _userHandler;
        public UserEngine(IUserHandler userHandler)
        {
            _userHandler = userHandler;
        }

        public async Task<UserEntity> CreateUserEntity(UserEntity newUser)
        {

           await _userHandler.Insert(newUser);
           await _userHandler.SaveChanges();

            return newUser;
        }

        public async Task<string> GetEmail(int id)
        {
            return await _userHandler.GetEmail(id);
        }

        public async Task<string> GetFirstname(int id)
        {
            return await _userHandler.GetFirstname(id);
        }

        public async Task<string> GetLastname(int id)
        {
            return await _userHandler.GetLastname(id);
        }

        public async Task<int> GetPrivilege(int id)
        {
            return await _userHandler.GetPrivilege(id);
        }

        public async Task<UserEntity> GetUser(int id)
        {
            var user = await _userHandler.GetById(id);
            return user;
        }

        public async Task<string> GetUsername(int id)
        {
            return await _userHandler.GetUsername(id);
        }

        public async Task<IEnumerable<UserEntity>> GetUsers()
        {
            return await _userHandler.GetAll();
        }

        public async Task<UserEntity> UpdateUser(UserEntity user, string email, string firstName, string lastName, string password, int privilege)
        {
            user.Email = email;
            user.Firstname = firstName;
            user.Lastname = lastName;
            user.Password = password;
            user.Privilege = privilege;
            await _userHandler.Update(user);
            return user;
        }
        public Task Delete(UserEntity user)
        {
            return _userHandler.Delete(user);

        }
    }
}
