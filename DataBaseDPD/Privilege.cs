using System;
namespace DataBaseDPD
{
    public class Privilege
    {
        string Tabla { get; set; }
        bool DELETE { get; set; }
        bool INSERT { get; set; }
        bool SELECT { get; set; }
        bool UPDATE { get; set; }

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
