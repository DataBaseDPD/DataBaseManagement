using System;
using System.Collections.Generic;

namespace DataBaseDPD
{
    public class User
    {
        string user;
        string passwrd;
        List<string> profiles;

        public User(string usr, string pass)
        {
            user = usr;
            passwrd = pass;
            profiles = new List<string>();
           
        }

        public bool isValid(string user , string password)
        {
            return false;
        }
    }
}
