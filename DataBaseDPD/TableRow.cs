﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseDPD
{
    public class TableRow
    {
        //Atributes
        List<string> tuple;

        //Constructor 
        public TableRow(string[] items)
        {
            tuple = new List<string>();
            for (int i = 0; i < items.Length; i++)
            {
                tuple.Add(items[i]);
            }
        }

        //Pos start at 0 
        public string getItem(int position)
        {
            return tuple[position];
        }
        //Not implement
        public string getItem(string columnName)
        {
            return null;
        }

        public List<string> getTuple()
        {
            return tuple;
        }
    }
}
