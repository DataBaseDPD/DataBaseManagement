using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace DataBaseDPD
{
	public class Parser

	{

        public static Query Parse(string query)
		{

			// SELECT
			//Con *:
			const string select1 = @"SELECT\s+(\*)\s+FROM\s+(\w+);";
			const string select2 = @"SELECT\s+(\w+)\s+FROM\s+(\w+);";
            
			
			//Insert
			const string insert1 = @"INSERT\s+INTO\s+(\w+)\s+VALUES\s+\(([\w\'\s+\.]+)\);"; //CON TODOS SUS VALUES(1)

			//Delete
			const string delete = @"DELETE\s+FROM\s+(\w+)\s+WHERE\s+(\w+)\s*(=|<|>)\s*(\w+);";

			//Update
			const string update1 = @"UPDATE\s+(\w+)\s+SET\s+(\w+)\s*(\=)\s*(\w+)(\,\s+(\w+)\s*(\=)\s*(\w+)\s+)WHERE\s+(\w+)\s*(=|<|>)\s*(\w+);"; //no traga comillas en los attbs ni espacios

			

			//Drop DB 
			const string dropDB = @"DROP\s+DATABASE\s+(\w+);";

			//Create DB
			const string createDB = @"CREATE\s+DATABASE\s+(\w+);";

			//Create Table
			//string createTable = @"(CREATE\s+TABLE)\s+(\w+)\s+\((\w+)\s+(INT|DOUBLE|TEXT)(\s+|\,\s+\w+\s+(INT|DOUBLE|TEXT))+)\,\s+(PRIMARY\s+KEY)\s+\((\w+)\)\,\s+(FOREIGN\s+KEY)\s+\((\w+)\)\s+REFERENCES\s+(\w+)\s+\((\w+)\);";
			const string createTable1 = @"CREATE\s+TABLE\s+(\w+)\s+\((\w+)\s+(INT|DOUBLE|TEXT)\);";
			const string createTable2 = @"CREATE\s+TABLE\s+(\w+)\s+\((\w+)\s+(INT|DOUBLE|TEXT)(\,\s+(\w+)\s+(INT|DOUBLE|TEXT))+\);";
			//Drop Table
			const string dropTable = @"DROP\s+TABLE\s+(\w+);";

           ////__-------------------------------------------------------------------------------------------

			//Select With where
			const string select3 = @"SELECT\s+(\w+)\s+FROM\s+(\w+)\s+WHERE\s+(\w+)\s*(=|<|>)\s*([\w\']+);";
			//Update with Where
			const string update2 = @"UPDATE\s+(\w+)\s+SET\s+(\w+)\s*(\=)\s*(\w+)\s+WHERE\s+(\w+)\s*(=|<|>)\s*(\w+);";



			//Select all from table
			Match match = Regex.Match(query, select1);
			if (match.Success)
			{
				string table = match.Groups[2].Value;
				return new SelectAll(table);
			}
            //Select columns
			match = Regex.Match(query, select2);
			if(match.Success)
            {
				List<string> columnNames = CommaSeparatedNames(match.Groups[1].Value);
				string table = match.Groups[2].Value;
				return new Select(table, columnNames);

			}

			// Insert todos valores
			 match = Regex.Match(query, insert1);
			if (match.Success)
			{
                //TODO
				return null;

			}

			// Delete
			match = Regex.Match(query, insert1);
			if (match.Success)
			{
				//TODO
				return null;

			}
			match = Regex.Match(query, insert1);
			if (match.Success)
			{
				//TODO
				return null;

			}
			match = Regex.Match(query, insert1);
			if (match.Success)
			{
				//TODO
				return null;

			}
			match = Regex.Match(query, insert1);
			if (match.Success)
			{
				//TODO
				return null;

			}
			match = Regex.Match(query, insert1);
			if (match.Success)
			{
				//TODO
				return null;

			}










			return null;

		}
		static List<string> CommaSeparatedNames(string text)
		{
			List<string> result = new List<string>();
			string[] separate = text.Split(',');
			for (int i = 0; i < separate.Length; i++)
			{
				result.Add(separate[i].Trim(' '));
			}
			return result;
		}
	}
}
