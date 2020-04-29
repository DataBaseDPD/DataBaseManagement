using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataBaseDPD;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TestDataBase
{
    [TestClass]
    public class UnitTestTable
    {
        [TestMethod]
        public void creatTableTest()
        {
            TableColumn col1 = new TableColumn("id", "int", 0);
            TableColumn col2 = new TableColumn("nombre", "string", 1);
            TableColumn col3 = new TableColumn("email", "string", 2);
            List<TableColumn> columns = new List<TableColumn>();
            columns.Add(col1);
            columns.Add(col2);
            columns.Add(col3);

            Table tabla = new Table("tablaTest", columns);

         
            Assert.IsNotNull(tabla);
        }
        
        [TestMethod]
        public void addTupleTest()
        {
            TableColumn col1 = new TableColumn("id", "int", 0);
            TableColumn col2 = new TableColumn("nombre", "string", 1);
            TableColumn col3 = new TableColumn("email", "string", 2);
            List<TableColumn> columns = new List<TableColumn>();
            columns.Add(col1);
            columns.Add(col2);
            columns.Add(col3);

            Table tabla = new Table("tablaTest", columns);
           
            tabla.addRow(new TableRow(new string[3] { "01", "david", "david@email.com" }));

            Assert.AreEqual(1,tabla.getNumRow());

            
        }
        [TestMethod]
        public void removeTupleTest()
		{
            TableColumn col1 = new TableColumn("id", "int", 0);
            TableColumn col2 = new TableColumn("nombre", "string", 1);
            TableColumn col3 = new TableColumn("email", "string", 2);
            List<TableColumn> columns = new List<TableColumn>();
            columns.Add(col1);
            columns.Add(col2);
            columns.Add(col3);

            Table tabla = new Table("tablaTest", columns);
            TableRow tuple = new TableRow(new string[3] { "01", "david", "david@email.com" });
            tabla.addRow(tuple);


            tabla.removeTuple(tuple);

            Assert.AreEqual(0, tabla.getNumRow());
        }
        [TestMethod]
        public void getTuplesTest()
        {
            TableColumn col1 = new TableColumn("id", "int", 0);
            TableColumn col2 = new TableColumn("nombre", "string", 1);
            TableColumn col3 = new TableColumn("email", "string", 2);
            List<TableColumn> columns = new List<TableColumn>();
            columns.Add(col1);
            columns.Add(col2);
            columns.Add(col3);

            Table tabla = new Table("tablaTest", columns);

            TableRow tuple1 = new TableRow(new string[3] { "01", "david", "david@email.com" });
            TableRow tuple2 = new TableRow(new string[3] { "02", "domenico", "domenico@email.com" });

            tabla.addRow(tuple1);
            tabla.addRow(tuple2);



            List<TableRow> tuples = tabla.getTuples();


            Assert.IsTrue(tuples.Contains(tuple1) && tuples.Contains(tuple2) );
        }
        [TestMethod]
        public void getColumnTest()
        {
            TableColumn col1 = new TableColumn("id", "int", 0);
            TableColumn col2 = new TableColumn("nombre", "string", 1);
            TableColumn col3 = new TableColumn("email", "string", 2);
            List<TableColumn> columns = new List<TableColumn>();
            columns.Add(col1);
            columns.Add(col2);
            columns.Add(col3);

            Table tabla = new Table("tablaTest", columns);

            TableRow tuple1 = new TableRow(new string[3] { "01", "david", "david@email.com" });
            TableRow tuple2 = new TableRow(new string[3] { "02", "domenico", "domenico@email.com" });

            tabla.addRow(tuple1);
            tabla.addRow(tuple2);



            List<string> column = tabla.getColumn("id");


            Assert.IsTrue(column.Contains("01") && column.Contains("02"));
         
        }

        [TestMethod]
        public void getFirstTupleTest()
        {
            TableColumn col1 = new TableColumn("id", "int", 0);
            TableColumn col2 = new TableColumn("nombre", "string", 1);
            TableColumn col3 = new TableColumn("email", "string", 2);
            List<TableColumn> columns = new List<TableColumn>();
            columns.Add(col1);
            columns.Add(col2);
            columns.Add(col3);

            Table tabla = new Table("tablaTest", columns);

            TableRow tuple1 = new TableRow(new string[3] { "01", "david", "david@email.com" });
            TableRow tuple2 = new TableRow(new string[3] { "02", "domenico", "domenico@email.com" });

            tabla.addRow(tuple1);
            tabla.addRow(tuple2);


             TableRow firstRow = tabla.getFirstRow();

            bool check1 = String.Equals("01", firstRow.getItem(0));
            bool check2 = String.Equals("david@email.com", firstRow.getItem(2));

            Assert.IsTrue(check1 && check2);
        }
        [TestMethod]
        public void getColNamesTest()
        {
            TableColumn col1 = new TableColumn("id", "int", 0);
            TableColumn col2 = new TableColumn("nombre", "string", 1);
            TableColumn col3 = new TableColumn("email", "string", 2);
            List<TableColumn> columns = new List<TableColumn>();
            columns.Add(col1);
            columns.Add(col2);
            columns.Add(col3);

            Table tabla = new Table("tablaTest", columns);

            List<string> names = tabla.getColNames();

            Assert.IsTrue(names.Contains("id") && names.Contains("email"));

        }
        [TestMethod]
        public void getTypeColumnTest()
        {
            TableColumn col1 = new TableColumn("id", "int", 0);
            TableColumn col2 = new TableColumn("nombre", "string", 1);
            TableColumn col3 = new TableColumn("email", "string", 2);
            List<TableColumn> columns = new List<TableColumn>();
            columns.Add(col1);
            columns.Add(col2);
            columns.Add(col3);

            Table tabla = new Table("tablaTest", columns);

            string type = tabla.getTypeColumn(0);
            string type2 = tabla.getTypeColumn("email");



            bool check1 = String.Equals("int", type);
            bool check2 = String.Equals("string", type2);

            Assert.IsTrue(check1 && check2);

        }

        [TestMethod]
        public void getNumColumTest()
        {
            TableColumn col1 = new TableColumn("id", "int", 0);
            TableColumn col2 = new TableColumn("nombre", "string", 1);
            TableColumn col3 = new TableColumn("email", "string", 2);
            List<TableColumn> columns = new List<TableColumn>();
            columns.Add(col1);
            columns.Add(col2);
            columns.Add(col3);

            Table tabla = new Table("tablaTest", columns);

            Assert.AreEqual(3, tabla.getNumColumn());
        }
        
        [TestMethod]
        public void getNumRowTest()
        {
            TableColumn col1 = new TableColumn("id", "int", 0);
            TableColumn col2 = new TableColumn("nombre", "string", 1);
            TableColumn col3 = new TableColumn("email", "string", 2);
            List<TableColumn> columns = new List<TableColumn>();
            columns.Add(col1);
            columns.Add(col2);
            columns.Add(col3);

            Table tabla = new Table("tablaTest", columns);

            TableRow tuple1 = new TableRow(new string[3] { "01", "david", "david@email.com" });
            TableRow tuple2 = new TableRow(new string[3] { "02", "domenico", "domenico@email.com" });

            tabla.addRow(tuple1);
            tabla.addRow(tuple2);


            Assert.AreEqual(2,tabla.getNumRow());
        }

        [TestMethod]
        public void getIndexColTest()
        {
            TableColumn col1 = new TableColumn("id", "int", 0);
            TableColumn col2 = new TableColumn("nombre", "string", 1);
            TableColumn col3 = new TableColumn("email", "string", 2);
            List<TableColumn> columns = new List<TableColumn>();
            columns.Add(col1);
            columns.Add(col2);
            columns.Add(col3);

            Table tabla = new Table("tablaTest", columns);


            Assert.AreEqual(0,tabla.getIndex("id"));
        }
        public void modifyTupleTest()
        {
            TableColumn col1 = new TableColumn("id", "int", 0);
            TableColumn col2 = new TableColumn("nombre", "string", 1);
            TableColumn col3 = new TableColumn("email", "string", 2);
            List<TableColumn> columns = new List<TableColumn>();
            columns.Add(col1);
            columns.Add(col2);
            columns.Add(col3);

            Table tabla = new Table("tablaTest", columns);

            TableRow tuple1 = new TableRow(new string[3] { "01", "david", "david@email.com" });
            TableRow tuple2 = new TableRow(new string[3] { "02", "domenico", "domenico@email.com" });

            tabla.addRow(tuple1);
            tabla.addRow(tuple2);


            tabla.modifyTuple(tuple2, "id", "33");
                
          

            Assert.IsTrue(String.Equals("33", tuple2.getItem(0)));
        }

        [TestMethod]
        public void saveTableTest()
        {
            //TODO
        }







        /**-------------------------------------------------
        Test de DataBase
        ---------------------------------------------------**/

        /**
         [TestMethod]
         public void CreatTableTest()
         {
             List<string> columns = new List<string>();
             columns.Add("id");
             columns.Add("nombre");
             columns.Add("email");
             List<string> types = new List<string>();
             types.Add("int");
             types.Add("string");
             types.Add("string");


             Database db = new Database();

             string result = db.CreateTable("tablaTest",columns,types);

             Assert.IsTrue(String.Equals("Table created ...", result));
         }
         [TestMethod]
         public void getTableTest()
         {
             TableColumn col1 = new TableColumn("id", "int", 0);
             TableColumn col2 = new TableColumn("nombre", "string", 1);
             TableColumn col3 = new TableColumn("email", "string", 2);
             List<TableColumn> columns = new List<TableColumn>();
             columns.Add(col1);
             columns.Add(col2);
             columns.Add(col3);

             Table tabla = new Table("tablaTest", columns);

             Database db = new Database();

             db.addTable("tablaTest", tabla);

             Assert.IsNotNull(db.getTable("tablaTest"));
      
         }

         [TestMethod]
         public void addTableTest()
         {
             TableColumn col1 = new TableColumn("id", "int", 0);
             TableColumn col2 = new TableColumn("nombre", "string", 1);
             TableColumn col3 = new TableColumn("email", "string", 2);
             List<TableColumn> columns = new List<TableColumn>();
             columns.Add(col1);
             columns.Add(col2);
             columns.Add(col3);

             Table tabla = new Table("tablaTest", columns);

             Database db = new Database();

             db.addTable("tablaTest", tabla);

             Assert.IsTrue(db.getTables().ContainsKey("tablaTest"));
            

         }
       
         
         [TestMethod]
         public void dropTableTest()
         {
             TableColumn col1 = new TableColumn("id", "int", 0);
             TableColumn col2 = new TableColumn("nombre", "string", 1);
             TableColumn col3 = new TableColumn("email", "string", 2);
             List<TableColumn> columns = new List<TableColumn>();
             columns.Add(col1);
             columns.Add(col2);
             columns.Add(col3);

             Table tabla = new Table("tablaTest", columns);
             Table tabla2 = new Table("tablaTest2", columns);

             Database db = new Database();

             db.addTable("tablaTest", tabla);
             db.addTable("tablaTest2", tabla2);

             db.DropTabla("tablaTest");

             Assert.IsTrue(!db.getTables().ContainsKey("tablaTest"));
         }
         
        [TestMethod]
        public void insertTest()
        {
             TableColumn col1 = new TableColumn("id", "int", 0);
             TableColumn col2 = new TableColumn("nombre", "string", 1);
             TableColumn col3 = new TableColumn("email", "string", 2);
             List<TableColumn> columns = new List<TableColumn>();
             columns.Add(col1);
             columns.Add(col2);
             columns.Add(col3);

             Table tabla = new Table("tablaTest", columns);

             Database db = new Database();

             db.addTable("tablaTest", tabla);

             List<string> valores = new List<string>();
             valores.Add("33");
             valores.Add("pepito");
             valores.Add("pepito@email.com");

             string result = db.Insert("tablaTest",valores);

             Assert.IsTrue(String.Equals("Tuple added", result));

         }
         
        [TestMethod]
        public void dropTableTest()
        {
        }
         
        [TestMethod]
        public void dropTableTest()
        {
        }
        [TestMethod]
        public void dropTableTest()
        {
        }
        [TestMethod]
        public void dropTableTest()
        {
        }

        **/

        //LOAD METHOD MUST BE IN DATABASE CLASS
        [TestMethod]
        public void LoadEmptyTableTest()
        {
            TableColumn col1 = new TableColumn("id", "int", 1);
            TableColumn col2 = new TableColumn("nombre", "string", 2);
            TableColumn col3 = new TableColumn("email", "string", 3);
            List<TableColumn> columns = new List<TableColumn>();
            columns.Add(col1);
            columns.Add(col2);
            columns.Add(col3);

            Table tabla = new Table("tablaTest", columns);
            tabla.save();
            Database db = new Database();
            Table loadedTable = db.load("tablaTest.txt");

            Assert.AreEqual(0, loadedTable.getNumRow());
        }
        [TestMethod]
        public void LoadTableTest()
        {
            TableColumn col1 = new TableColumn("id", "int", 1);
            TableColumn col2 = new TableColumn("nombre", "string", 2);
            TableColumn col3 = new TableColumn("email", "string", 3);
            List<TableColumn> columns = new List<TableColumn>();
            columns.Add(col1);
            columns.Add(col2);
            columns.Add(col3);

            Table tabla = new Table("tablaTest", columns);

            tabla.addRow(new TableRow(new string[3] { "01", "david", "david@email.com" }));
            tabla.addRow(new TableRow(new string[3] { "02", "domenico", "domenico@email.com" }));

            tabla.save();

            Database db = new Database();

            Table loadedTable = db.load("tablaTest.txt");
          
            Assert.AreEqual(2, loadedTable.getNumRow());

        }








        /**-------------------------------------------------
        Test de Parser
        ---------------------------------------------------**/

        /**CreateTAble Probados
            string query = "CREATE TABLE MyTable (Name TEXT, Age INT, Address TEXT);";
            string query2 = "CREATE TABLE Employees(Id INT,Name TEXT,Surname TEXT,Salary DOUBLE);";

            string query3 = "CREATE TABLE MyTable (Name TEXT,Age INT,Address TEXT)";
            string query5 = "CREATE TABLE MyTable (Name TEXT,Age INT,Address )";
            string query4 = "CREATE TABLE MyTable (Name TEXT, Age INT, Address TEXT);";




            insert
            string q2 = "INSERT INTO MyTable VALUES ('Eva',18,'Calle Los Herran 16 2 Derecha. 01005 Vitoria-Gasteiz');";
            string q3 = "INSERT INTO Employees VALUES (3,'Benito','Kamelas',1100);";


            string q4 = "INSERT INTO Employees VALUES (3,'Benito','Kamelas');";
            string q5 = "INSERT INTO MyTable VALUES ('Eva',18,'Calle Los Herran 16 2 Derecha. 01005 Vitoria-Gasteiz','sobra');";


            update
            string q6 = "UPDATE Employees_Public SET Name='Maite';"


            select

            string q7 = "SELECT * FROM MyTable;";
            string q8 = "SELECT Name,Age FROM MyTable;";
            string q9 = "SELECT Name, Age FROM MyTable WHERE Name='Miren';";


         *
         * **/






    }
}
