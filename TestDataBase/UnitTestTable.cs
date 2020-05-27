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

            Assert.AreEqual(1, tabla.getNumRow());


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


            Assert.IsTrue(tuples.Contains(tuple1) && tuples.Contains(tuple2));
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


            Assert.AreEqual(2, tabla.getNumRow());
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


            Assert.AreEqual(0, tabla.getIndex("id"));
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
        public void LoadEmptyTableTest()
        {
            TableColumn col1 = new TableColumn("id", "int", 1);
            TableColumn col2 = new TableColumn("nombre", "string", 2);
            TableColumn col3 = new TableColumn("email", "string", 3);
            List<TableColumn> columns = new List<TableColumn>();
            columns.Add(col1);
            columns.Add(col2);
            columns.Add(col3);

            Database db = new Database();

            Table tabla = new Table("tablaTest", columns);
            tabla.save(db.getSourceDir());

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

            Database db = new Database();

            Table tabla = new Table("tablaTest", columns);

            tabla.addRow(new TableRow(new string[3] { "01", "david", "david@email.com" }));
            tabla.addRow(new TableRow(new string[3] { "02", "domenico", "domenico@email.com" }));

            tabla.save(db.getSourceDir());


            Table loadedTable = db.load("tablaTest.txt");

            Assert.AreEqual(2, loadedTable.getNumRow());

        }

        [TestMethod]
        public void saveTableTest()
        {
            //TODO
        }


        /**-------------------------------------------------
        Test de DataBase
        ---------------------------------------------------**/

        [TestMethod]
        public void creatDataBaseTest()
        {
            //TODO
        }
        [TestMethod]
        public void creatDataBaseTest2()
        {
            //TODO
        }
        [TestMethod]
        public void getTableTest()
        {
            //TODO
        }
        [TestMethod]
        public void addTableTest()
        {
            //TODO
        }
        [TestMethod]
        public void getTablesTest()
        {
            //TODO
        }
        [TestMethod]
        public void loadTablesTest()
        {
            //TODO
        }
        [TestMethod]
        public void CreateTableTest()
        {
            //TODO
        }
        [TestMethod]
        public void DropTableTest()
        {
            //TODO
        }
        [TestMethod]
        public void InsertTest()
        {
            //TODO
        }
        [TestMethod]
        public void UpdateTest()
        {
            //TODO
        }
        [TestMethod]
        public void UpdateTest2()
        {
            //TODO
        }
        [TestMethod]
        public void SelectTest()
        {
            //TODO
        }
        [TestMethod]
        public void SelectTest2()
        {
            //TODO
        }
        [TestMethod]
        public void SelectTest3()
        {
            //TODO
        }
        [TestMethod]
        public void SelectTest4()
        {
            //TODO
        }
        [TestMethod]
        public void DeleteTest()
        {
            //TODO
        }

        /**-------------------------------------------------
        Test de Parser
        ---------------------------------------------------**/

        [TestMethod]
        public void Select1()
        {
            Query query = Parser.Parse("SELECT Name, Age, Height FROM People;");
            Select selectQuery = query as Select;

            Assert.IsTrue(selectQuery.Columns.Contains("Name"));
            Assert.IsTrue(selectQuery.Columns.Contains("Age"));
            Assert.IsTrue(selectQuery.Columns.Contains("Height"));
            Assert.AreEqual("People", selectQuery.Table);
        }
        [TestMethod]
        public void Select2()
        {
            Query query = Parser.Parse("SELECT * FROM People;");
            Select selectQuery = query as Select;

            Assert.AreEqual("People", selectQuery.Table);
        }
        [TestMethod]
        public void Select3()
        {
            Query query = Parser.Parse("SELECT Name, Age FROM People WHERE Age>17;");
            Select selectQuery = query as Select;

            Assert.IsTrue(selectQuery.Columns.Contains("Name"));
            Assert.IsTrue(selectQuery.Columns.Contains("Age"));
            Assert.AreEqual("Age", selectQuery.Col);
            Assert.AreEqual(">", selectQuery.Operation);
            Assert.AreEqual("17", selectQuery.Value);
            Assert.AreEqual("People", selectQuery.Table);
        }

        [TestMethod]
        public void CreateTable1()
        {
            Query query = Parser.Parse("CREATE TABLE MyTable (Name TEXT, Age INT, Address TEXT);");
            CreateTable selectQuery = query as CreateTable;

            Assert.IsTrue(selectQuery.columnNames.Contains("Name"));
            Assert.IsTrue(selectQuery.columnNames.Contains("Age"));
            Assert.IsTrue(selectQuery.columnNames.Contains("Address"));
            Assert.IsTrue(selectQuery.dataType.Contains("TEXT"));
            Assert.IsTrue(selectQuery.dataType.Contains("INT"));

            Assert.AreEqual("MyTable", selectQuery.Table);
        }

        public void CreateTable2()
        {
            Query query = Parser.Parse("CREATE TABLE Employees(Id INT,Name TEXT,Surname TEXT,Salary DOUBLE);");
            CreateTable selectQuery = query as CreateTable;

            Assert.IsTrue(selectQuery.columnNames.Contains("Id"));
            Assert.IsTrue(selectQuery.columnNames.Contains("Name"));
            Assert.IsTrue(selectQuery.columnNames.Contains("Surname"));
            Assert.IsTrue(selectQuery.columnNames.Contains("Salary"));
            Assert.IsTrue(selectQuery.dataType.Contains("TEXT"));
            Assert.IsTrue(selectQuery.dataType.Contains("INT"));
            Assert.IsTrue(selectQuery.dataType.Contains("DOUBLE"));

            Assert.AreEqual("Employees", selectQuery.Table);
        }
        [TestMethod]
        public void DropTable()
        {
            Query query = Parser.Parse("DROP TABLE Employees;");
            DropTable selectQuery = query as DropTable;

            Assert.AreEqual("Employees", selectQuery.Table);
        }
        [TestMethod]
        public void Update1()
        {
            Query query = Parser.Parse("UPDATE Employees_Public SET Name='Maite';");
            Update selectQuery = query as Update;


            Assert.IsTrue(selectQuery.ColNames.Contains("Name"));
            Assert.IsTrue(selectQuery.Values.Contains("'Maite'"));
            Assert.AreEqual("Employees_Public", selectQuery.Tabla);
        }
        [TestMethod]
        public void Update2()
        {
            Query query = Parser.Parse("UPDATE Employees_Public SET Name='Maite' WHERE Age=18;");
            Update selectQuery = query as Update;


            Assert.IsTrue(selectQuery.ColNames.Contains("Name"));
            Assert.IsTrue(selectQuery.Values.Contains("'Maite'"));
            Assert.AreEqual("Age", selectQuery.ColCondition);
            Assert.AreEqual("=", selectQuery.Operation);
            Assert.AreEqual("18", selectQuery.Value);
            Assert.AreEqual("Employees_Public", selectQuery.Tabla);
        }
        [TestMethod]
        public void Delete()
        {

            Query query = Parser.Parse("DELETE FROM MyTable WHERE Age=18;");
            Delete selectQuery = query as Delete;

            Assert.AreEqual("Age", selectQuery.colCondition);
            Assert.AreEqual("=", selectQuery.Operation);
            Assert.AreEqual("18", selectQuery.Value);
            Assert.AreEqual("MyTable", selectQuery.Tabla);

        }
        [TestMethod]
        public void Insert()
        {
            Query query = Parser.Parse("INSERT INTO Employees VALUES (3,'Benito','Kamelas');");
            Insert selectQuery = query as Insert;

            Assert.IsTrue(selectQuery.Values.Contains("3"));
            Assert.IsTrue(selectQuery.Values.Contains("'Benito'"));
            Assert.IsTrue(selectQuery.Values.Contains("'Kamelas'"));
            Assert.AreEqual("Employees", selectQuery.Tabla);
        }

        /**-------------------------------------------------
        Test de RunQueries
        ---------------------------------------------------**/

        [TestMethod]
        public void RunSelectTest()
        {
            //TODO
        }

    }
}
