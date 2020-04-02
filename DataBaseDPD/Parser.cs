using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace DataBaseDPD
{
	public class Parser

	{

        public static Query Parse(string query)
		{
			Match match;

			//Create Table  
			const string createTable = @"CREATE TABLE\s+(\w+)\s+\(([^\)]+)\)\s*\;";
			//Drop Table
			const string dropTable = @"DROP\s+TABLE\s+(\w+);";
			// Select
			const string select1 = @"SELECT\s+([^\)]+)\s+FROM\s+(\w+)\;";
			const string select2 = @"SELECT\s+(\*)\s+FROM\s+(\w+);";

			//Update
			const string update1 = @"UPDATE\s+(\w)\s+SET\s+[(\w)\=(\w)]+\s*\;";

			//Insert
			const string insert1 = @"INSERT\s+INTO\s+(\w+)\s+VALUES\s+\(([^\)]+)\)\;"; //CON TODOS SUS VALUES(1)

			const string nada = @"CT\s+(\w+)\s+FROM\s";




			//CreateTable //FUNCIONA
			match = Regex.Match(query, createTable);
			if (match.Success)
			{
                
				String nombreTabla = match.Groups[1].Value;
				string data = match.Groups[2].Value;
				return new CreateTable(nombreTabla, data);
			}


            //DropTable //FUNCIONA
			match = Regex.Match(query, dropTable);
			if (match.Success)
			{
				String nombreTabla = match.Groups[1].Value;
				return new DropTable(nombreTabla );

			}
			//Select columns //FUNCIONA
			match = Regex.Match(query, select1);
			if (match.Success)
			{
				List<string> columnNames = CommaSeparatedNames(match.Groups[1].Value);
				string table = match.Groups[2].Value;
				return new Select(table, columnNames);

			}
			//Select all //FUNCIONA
			match = Regex.Match(query, select2);
			if (match.Success)
			{
				string table = match.Groups[2].Value;
				return new Select(table);
			}
            
			// Insert //FUNCIONA
			 match = Regex.Match(query, insert1);
			if (match.Success)
			{
				string nameTable = match.Groups[1].Value;
				List<string> values = CommaSeparatedNames(match.Groups[2].Value);
				return new Insert(nameTable, values);

			}
            //Update solo igualdad de atributos
			match = Regex.Match(query, update1);
			if (match.Success)
			{
				String nombreTabla = match.Groups[1].Value;
				List<string> columns = CommaSeparatedNames(match.Groups[2].Value);
				List<string> values = CommaSeparatedNames(match.Groups[3].Value);
				return new Update(nombreTabla,columns,values);

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
