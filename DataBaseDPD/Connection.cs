using System;
using System.Collections.Generic;
using System.IO;

namespace DataBaseDPD
{
    public class Connection
    {
        Database Db;
        User User;
        List<User> Users;
        public Dictionary<string, Profile> Profiles;//Key profile`s name, value the tables with the privileges
        bool connected;

        string sourceDir = PATH.GetPath();


        /**
         *Connection Methods
         *
         */

        public Connection()
        {
            this.Users = loadUsers();
            this.Profiles = loadProfiles();
        }
        public string Connect(string database, string user, string password)
        {
            //Con este metodo se pueden introducir mas de un usuario iguales, mas solo devolveria el primero
            this.User = getUser(user);

            try
            {
                if (User.isValid(user, password))
                {
                    connected = true;
                    Db = new Database(database);

                    return Message.OpenDatabaseSuccess;
                }
                else
                {
                    connected = false;
                    return Message.SecurityIncorrectLogin;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return Message.SecurityIncorrectLogin;

            }


        }
        public bool isConnected()
        {
            return connected;
        }

      
        public void Close()    
        {
            saveUsers();
            saveProfiles();
            User = null;
            Db = null;
            connected = false;
            
        }




        public string RunQuery(string query)
        {
            Query request = Parser.Parse(query);
            //Data of the request

            if (request == null)
            {
                return Message.WrongSyntax;
            }
            else
            {
                PrivilegeType privRequire = request.getType();
                string tabla = request.getTableName();




                if (this.User.isAdmin() && privRequire == PrivilegeType.ADMIN) return request.Run(this);
                else if (this.User.isAdmin() && privRequire == PrivilegeType.OTHER) return request.Run(this.Db);//Si la query es
                                                                                                                //de tipo admin se ejecute en Connection no en Database
                else if (this.User.isAdmin() && privRequire == PrivilegeType.DELETE) return request.Run(this.Db);
                else if (this.User.isAdmin() && privRequire == PrivilegeType.INSERT) return request.Run(this.Db);
                else if (this.User.isAdmin() && privRequire == PrivilegeType.SELECT) return request.Run(this.Db);
                else if (this.User.isAdmin() && privRequire == PrivilegeType.UPDATE) return request.Run(this.Db);
                else
                {
                    //Data user
                    Privilege priv = userPrivilege(tabla);

                    if (priv.DELETE && privRequire == PrivilegeType.DELETE) return request.Run(this.Db);
                    else if (priv.INSERT && privRequire == PrivilegeType.INSERT) return request.Run(this.Db);
                    else if (priv.SELECT && privRequire == PrivilegeType.SELECT) return request.Run(this.Db);
                    else if (priv.UPDATE && privRequire == PrivilegeType.UPDATE) return request.Run(this.Db);
                    else return Message.SecurityNotSufficientPrivileges;
                }
            }



        }
        public User getUser(string user)
        {
            bool encontrado = false;
            int i = 0;
            User usr = null;
            while (!encontrado && Users.Count > i)
            {
                if (this.Users[i].user == user)
                {
                    usr = this.Users[i];
                    encontrado = true;
                }
                else i++;

            }
            return usr;
        }
        public List<User> getUsers()
        {
            return this.Users;
        }
        public Dictionary<string, Profile> getProfiles()
        {
            return this.Profiles;
        }
        private Privilege userPrivilege(string nameTable)
        {
            Profile prof;
            Privilege priv = new Privilege(nameTable);
            foreach (string p in User.profiles)
            {
                this.Profiles.TryGetValue(p, out prof);

                if (prof != null)
                {
                    if (prof.privileges.ContainsKey(nameTable))
                    {
                        prof.privileges.TryGetValue(nameTable, out priv);

                    }

                }
            }
            return priv;
        }
        /**
         * Queries Methods
         **/
        public string AddUser(string user, string pass, string profile)
        {
            if (getUser(user) == null)
            {
                User usr = new User(user, pass);
                usr.profiles.Add(profile);
                this.Users.Add(usr);
                return Message.SecurityUserAdded;
            }
            else return Message.SecurityUserAlreadyExists;

        }
        public string CreateProfile(string profile)
        {
            if (!this.Profiles.ContainsKey(profile))
            {
                this.Profiles.Add(profile, new Profile(profile));
                return Message.SecurityProfileCreated;
            }
            else return Message.SecurityProfileAlreadyExists;

        }
        public string DeleteUser(string user)
        {
            //USER ADMIN CANNOT BE DELETED
            User usr = getUser(user);
            if (usr != null && !usr.isAdmin())
            {
                this.Users.Remove(usr);
                return Message.SecurityUserDeleted;
            }
            else return Message.SecurityUserDoesNotExist;

        }
        public string DropProfile(string profile)
        {
            if (this.Profiles.ContainsKey(profile))
            {
                this.Profiles.Remove(profile);
                return Message.SecurityProfileDeleted;
            }
            else return Message.SecurityProfileDoesNotExist;
        }
        public string GrantPrivilege(string profile, string table, string privilege)
        {
            if (this.Profiles.ContainsKey(profile))
            {
                this.Profiles.TryGetValue(profile, out Profile prof);
                if (prof.privileges.ContainsKey(table))//SI EXISTE EL PRIVILEGIO SOBRE ESA TABLA LO MODIFICAMOS
                {
                    prof.privileges.TryGetValue(table, out Privilege priv);
                    if (privilege == "DELETE") priv.DELETE = true;
                    else if (privilege == "INSERT") priv.INSERT = true;
                    else if (privilege == "SELECT") priv.SELECT = true;
                    else if (privilege == "UPDATE") priv.UPDATE = true;
                }
                else//SI NO EXISTE EL PRIVILEGIO SOBRE ESA TABLA LO CREAMOS Y ANADIMOS
                {
                    Privilege priv = new Privilege(table);
                    if (privilege == "DELETE") priv.DELETE = true;
                    else if (privilege == "INSERT") priv.INSERT = true;
                    else if (privilege == "SELECT") priv.SELECT = true;
                    else if (privilege == "UPDATE") priv.UPDATE = true;
                    prof.privileges.Add(table, priv);
                }
                return Message.SecurityPrivilegeGranted;
            }
            else return Message.SecurityProfileDoesNotExist;
        }
        public string RevokePrivilege(string profile, string table, string privilege)
        {
            if (this.Profiles.ContainsKey(profile))
            {
                this.Profiles.TryGetValue(profile, out Profile prof);
                if (prof.privileges.ContainsKey(table))
                {
                    prof.privileges.TryGetValue(table, out Privilege priv);
                    if (privilege == "DELETE") priv.DELETE = false;
                    else if (privilege == "INSERT") priv.INSERT = false;
                    else if (privilege == "SELECT") priv.SELECT = false;
                    else if (privilege == "UPDATE") priv.UPDATE = false;
                }

                return Message.SecurityPrivilegeRevoked;
            }
            else return Message.SecurityProfileDoesNotExist;
        }

        /**
         * File Methods
         **/
        public List<User> loadUsers()
        {
            string path = Path.Combine(sourceDir, "users.txt");
            List<User> users = new List<User>();
            try
            {
                if (File.Exists(path))
                {
                    StreamReader file = new StreamReader(path);

                    User usr;
                    string line;

                    while ((line = file.ReadLine()) != null)
                    {

                        string[] lineParts = line.Split(',');
                        //foreach (string s in lineParts) Console.WriteLine(s);
                        if (lineParts.Length > 1)
                        {
                            usr = new User(lineParts[0], lineParts[1]);//add user
                            if (lineParts.Length == 3)//add profiles
                                for (int i = 2; i < lineParts.Length; i++) usr.profiles.Add(lineParts[i]);
                            users.Add(usr);
                        }
                    }
                    file.Close();
                }
                else
                {
                    Console.WriteLine("Users are empty");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return users;

        }
        public void saveUsers()
        {
            try
            {

                string path = Path.Combine(sourceDir, "users.txt");
                StreamWriter writer = File.CreateText(path);
                foreach (User usr in this.Users)
                {
                    writer.Write(usr.user + "," + usr.passwrd + ",");
                    for (int i = 0; i < usr.profiles.Count; i++)
                        if (i == usr.profiles.Count - 1) writer.Write(usr.profiles[i] + "\n");
                        else writer.Write(usr.profiles[i] + ",");
                }

                writer.Close();
                //Console.WriteLine("Saved ...");
            }
            catch (Exception e)
            {
                Console.WriteLine("Not Saved ...");
                Console.WriteLine(e.StackTrace);
            }
        }
        public Dictionary<string, Profile> loadProfiles()
        {
            string path = Path.Combine(sourceDir, "profiles.txt");

            Dictionary<string, Profile> profiles = new Dictionary<string, Profile>();

            if (File.Exists(path))
            {
                StreamReader file = new StreamReader(path);

                Privilege priv;
                Profile prof;
                string line;

                while ((line = file.ReadLine()) != null)
                {

                    string[] lineParts = line.Split(';');
                    //Console.WriteLine(lineParts.Length);
                    prof = new Profile(lineParts[0]);
                    for (int i = 1; i < lineParts.Length; i = i + 5)
                    {
                        priv = new Privilege(lineParts[i]);//Table's name
                        if (lineParts[i + 1] == "DELETE") priv.DELETE = true;
                        if (lineParts[i + 2] == "INSERT") priv.INSERT = true;
                        if (lineParts[i + 3] == "SELECT") priv.SELECT = true;
                        if (lineParts[i + 4] == "UPDATE") priv.UPDATE = true;
                        prof.privileges.Add(lineParts[i], priv);
                    }

                    profiles.Add(lineParts[0], prof);
                }
                file.Close();
            }
            else
            {
                Console.WriteLine("Profiles are empty");
            }

            return profiles;
        }
        public void saveProfiles()
        {
            string path = Path.Combine(sourceDir, "profiles.txt");
            StreamWriter writer = File.CreateText(path);

            Profile prof;
            Privilege priv;


            foreach (KeyValuePair<string, Profile> entry in this.Profiles)
            {
                prof = entry.Value;
                writer.Write(entry.Key);//Profile's name
                foreach (KeyValuePair<string, Privilege> entry2 in prof.privileges)
                {
                    writer.Write(";" + entry2.Key + ";");//Table's name
                    priv = entry2.Value;
                    if (priv.DELETE) writer.Write("DELETE;");
                    else if (!priv.DELETE) writer.Write("-;");
                    if (priv.INSERT) writer.Write("INSERT;");
                    else if (!priv.INSERT) writer.Write("-;");
                    if (priv.SELECT) writer.Write("SELECT;");
                    else if (!priv.SELECT) writer.Write("-;");
                    if (priv.UPDATE) writer.Write("UPDATE");
                    else if (!priv.UPDATE) writer.Write("-");

                }


            }
            writer.Close();

        }
    }
}

