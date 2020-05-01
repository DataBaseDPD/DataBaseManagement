using System;
namespace DataBaseDPD
{
    public class CreateProfile : Query
    {
        string Name;
        public CreateProfile(string name)
        {
            Name = name;
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
            return connection.CreateProfile(Name);
        }
    }
}
