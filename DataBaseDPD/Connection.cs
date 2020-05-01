using System;
using System.Collections.Generic;


namespace DataBaseDPD
{
    public class Connection
    {
        Database Db;
        User User;
        List<User> Users;
        bool connected;

        string sourceDir = @"../Debug/";

        public Connection()
        {
            Users = new List<User>();
            //Se deberian cargar los datos de para verificar que usuario y perimisos tiene
        }
        public string Connect(string database, string user, string password)
        {
            if (isValid(user, password))
            {
                connected = true;
                Db = new Database(database);
                return Message.OpenDatabaseSuccess;
            }
            else return Message.SecurityIncorrectLogin;
        }
        public Boolean isValid(string user, string password)
        {
            return User.isValid(user, password);
        }
        public bool isConnected()
        {
            User = null;
            Db = null;
            return connected;
        }

        public void close()
        {
            connected = false;
        }
        public string RunQuery(string query)
        {
            Query request = Parser.Parse(query);
            //Data of the request
            PrivilegeType privRequire = request.getType();
            string tabla = request.getTableName();
            //Verificar que tiene el privilegio para hacer esa operacion sobre esa tabla




            return null;
        }

        public void loadUsers()
        {
            string path = sourceDir + "users.txt";

        }
        public void loadProfiles()
        {
            string path = sourceDir + "profiles.txt";

        }

    }
}
