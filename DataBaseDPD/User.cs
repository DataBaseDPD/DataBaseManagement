using System;
using System.Collections.Generic;
using System.IO;

namespace DataBaseDPD
{
    public class User
    {
        public string user { get; set; }
        public string passwrd { get; set; }
        public List<string> profiles { get; set; }



        public User(string usr, string pass)
        {
            user = usr;
            passwrd = pass;
            profiles = new List<string>();
           
        }

        public bool isValid(string usr , string pass)
        {
            if (this.user == usr && this.passwrd==pass) return true;
            else return false;
        }
        public bool isAdmin()
        {
            bool isAdmin = false;
            int i = 0;
            while (!isAdmin && i<profiles.Count)
            {
                if (this.profiles[i] == "admin") isAdmin = true;
                i++;
            }
            return isAdmin;
        }
        
        
        
    }
}
