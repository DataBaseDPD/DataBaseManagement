using System;
using System.Collections.Generic;

namespace DataBaseDPD
{
    public class Profile
    {
        string Name;
        public Dictionary<string, Privilege>  privileges;

        //Los privilegios tendran como clave la tabla y valor los privilegios

        public Profile(string name)
        {
            Name = name;
            privileges = new Dictionary<string, Privilege>();

        }
        public void addPrivilege(string tabla, string privi)
        {
           //Si contiene la tabla le hacemos un set sopre el privilegio que se quire cambiar
        }

      

        
    }
}
