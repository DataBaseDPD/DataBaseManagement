using System;
namespace DataBaseDPD
{
    public class RevokePrivilege : Query
    {
        string Profile;
        string Tabla;
        string Privilege;

        public RevokePrivilege(string profile, string tabla, string privilege)
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
            return Tabla;
        }

        public override string Run(Connection connection)
        {
            return connection.RevokePrivilege(Profile,Tabla,Privilege);
        }
    }
}
