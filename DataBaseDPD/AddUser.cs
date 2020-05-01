using System;
using System.Collections.Generic;

namespace DataBaseDPD
{
    public class AddUser : Query
    {
        string User;
        string Passwrd;
        string Profile;

        public AddUser(List<string> data)
        {
            try
            {
                User = data[0];
                Passwrd = data[1];
                Profile = data[2];
            }
            catch (Exception  e)
            {
                Console.WriteLine("Wrong data to add user.");
                Console.WriteLine(e.StackTrace);
            }
            
        }

        public override string getTableName()
        {
            return null;
        }

        public override PrivilegeType getType()
        {
            return PrivilegeType.ADMIN;
        }

        public override string Run(Database database)
        {
            throw new NotImplementedException();
        }

        public override string Run(Connection connection)
        {
            return connection.AddUser(User,Passwrd,Profile);
        }
    }
}
