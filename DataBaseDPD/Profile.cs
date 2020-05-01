using System;
using System.Collections.Generic;

namespace DataBaseDPD
{
    public class Profile
    {
        string Name;
        public Dictionary<string, Privilege>  privileges;//Key is name's Table and Value the privileges

        

        public Profile(string name)
        {
            Name = name;
            privileges = new Dictionary<string, Privilege>();

        }
       public Privilege getPrivilege(string tabla)
        {
            privileges.TryGetValue(tabla, out Privilege priv);
            return priv;
        }

      

        
    }
}
