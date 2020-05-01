using System;
namespace DataBaseDPD
{
    public class GrantPrivilege : Query
    {
        string Profile;
        string Tabla;
        string Privilege;

        public GrantPrivilege(string profile, string tabla, string privilege)
        {
            Profile = profile;
            Tabla = tabla;
            Privilege = privilege;
        }

        public override string getTableName()
        {
            return Tabla;
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
            return connection.GrantPrivilege(Profile,Tabla,Privilege);
        }
    }
}
