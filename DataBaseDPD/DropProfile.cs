using System;
namespace DataBaseDPD
{
    public class DropProfile : Query
    {
        string Profile;

        public DropProfile(string profile)
        {
            Profile = profile;
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
    }
}
