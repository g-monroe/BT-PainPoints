using BTSuggestions.Core.Entities;
using BTSuggestions.Managers.RequestObjects;
using BTSuggestions.Managers.ResponseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BTSuggestions.Managers.Extensions
{
    public static class UserExtension
    {
        public static UserResponseList UserToListResponse(this IEnumerable<UserEntity> me)
        {
            var resp = new UserResponseList
            {
                TotalResults = me.Count(),
                UsersList = me.Select(x => x.UserToListItem()).ToList()
            };
            return resp;
        }
        public static UserResponse UserToListItem(this UserEntity me)
        {
            return new UserResponse()
            {
                UserId = me.Id,
                Email = me.Email,
                Username = me.Username,
                FirstName = me.Firstname,
                LastName = me.Lastname,
                Password = me.Password,
                Privilege = me.Privilege
            };
        }
        public static UserEntity UserToDbItem(this UserRequest me, UserEntity updating = null)
        {
            if (updating == null)
            {
                updating = new UserEntity();
            }
            updating.Id = me.UserId;
            updating.Email = me.Email;
            updating.Username = me.Username;
            updating.Firstname = me.FirstName;
            updating.Lastname = me.LastName;
            updating.Password = me.Password;
            updating.Privilege = me.Privilege;
            return updating;
        }
    }
}
