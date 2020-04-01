using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace DataBaseDPD
{
	public class Parser
	{
		public static Query Parse(string query)
		{

			const string select = @"SELECT\s+(\*|\w+)\s+FROM\s+(\w+)(?:\s+WHERE\s+(\w+)\s+(\=|\<|\>)\s+(\w+))?(\;)";
			const string update = @"UPDATE\s+(\w+)\s+SET\s+([\w\,\=\@\.]+)\s+WHERE\s+(\w+)\s*(=|<|>)\s*(\w+);";
			const string delete = @"DELETE\s+FROM\s+(\w+)(?:\s+WHERE\s+(\w+)\s+(\=|<|>)\s+(\w+))?(\;)";
			const string insert = @"INSERT\s+INTO\s+(\w+)\s+\(([^\)]+)\)\s+VALUES\s+\(([^\)]+)\);";
			

			const string createDataBase = @"CREATE DATABASE\s+(|\w+)(\;)";
			const string dropDataBase = @"DROP DATABASE\s+(\w+)(\;)";
			const string dropTable = @"DROP TABLE\s+(\*|\w+)(\;)";
			const string createTable = @"CREATE TABLE\s+(\w+)\s+\(([^\)]+)\)\s*\;";




			//Select
			Match match = Regex.Match(query, select);
			if (match.Success)
			{
				//mirar la lista

				return new Select();
			}

			//Insert
			match = Regex.Match(query, insert);
			if (match.Success)
			{
				String table = match.Groups[1].Value;
				String columns = match.Groups[2].Value;
				String values = match.Groups[3].Value;

				return new Insert(table, columns, values);
			}



			//Delete


			//CreateTable

			match = Regex.Match(query, createTable);
            if(match.Success)
				{

				String nombreTabla = match.Groups[1].Value;
				String tipoDato = match.Groups[2].Value;
				return new CreateTable(nombreTabla, tipoDato);

            }

			//DropTable







			//CreateDatabase

			match = Regex.Match(query,createDataBase);
            {

                if (match.Success)
                {

					String nombreDB = match.Groups[0].Value;
					return new CreateDataBase(nombreDB);

                }

            }


			//DropDatabase

			match = Regex.Match(query, dropDataBase);

			if(match.Success)
            {

				String nombreDB = match.Groups[0].Value;
				return new DropDataBase(nombreDB);

            }





		}
	}
}
