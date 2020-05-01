using System;
namespace DataBaseDPD
{
    public class DeleteUser : Query
    {
        string User;
        public DeleteUser(string user)
        {
            User = user;
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
            return connection.DeleteUser(User);
        }
    }
}
