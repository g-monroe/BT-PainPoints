using System;
using System.Collections.Generic;
using System.Text;

namespace BTSuggestions.Managers.RequestObjects
{
    public class UserRequest
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public int Privilege { get; set; }
    }
}
