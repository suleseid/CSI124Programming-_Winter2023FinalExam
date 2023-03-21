using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;

namespace ClassLibrary
{
    public class UserAccount
    {
        //Fields and Properties for all
        public enum Role { UserRole, Admin}
        string _name;
        string _username;
        string _password;
        Role _userRole;

        public string Name { get => _name; set => _name = value; }
        public string Username { get => _username; set => _username = value; }
        public string Password { get => _password; set => _password = value; }
        public Role UserRole { get => _userRole; set => _userRole = value; }

        public UserAccount(string name, string username, string password, Role userRole)
        {
            _name = name;
            _username = username;
            _password = password;
            _userRole = userRole;
        }

        //Required to saving CSV and Json files, as a defoult constractor and Properties with set.
        public UserAccount()
        {

        }

        public UserAccount(string name, string username, string password, string userRole)
        {
            Name = name;
            Username = username;
            Password = password;
        }

        //Lets create a Methods
        // Used for login
        public bool IsUser(string userName)
        {
            return _username == userName;
        }

        // Used for login
       
        public bool ValidateUser(string userName, string password)
        {
            return _username == userName && _password == password;
        }

        
    }
}
