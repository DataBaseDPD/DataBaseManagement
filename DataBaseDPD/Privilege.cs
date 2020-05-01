using System;
namespace DataBaseDPD
{
    public class Privilege
    {
        string Tabla { get; set; }
        public bool DELETE { get; set; }
        public bool INSERT { get; set; }
        public bool SELECT { get; set; }
        public bool UPDATE { get; set; }


        public Privilege(string nameTable)
        {
            Tabla = nameTable;
            DELETE = false;
            INSERT = false;
            SELECT = false;
            UPDATE = false;
        }

        public Privilege(string nameTable, bool delete,bool insert, bool select,bool update)
        {
            Tabla = nameTable;
            DELETE = delete;
            INSERT = insert;
            SELECT = select;
            UPDATE = update;
        }

    }
}
