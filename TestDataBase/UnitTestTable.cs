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


            tabla.remove(tuple);

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

            string type = tabla.getTypeColumn(1);
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


            Assert.AreEqual(2,tabTest.getNumRow());
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


            Assert.AreEqual(1,tabla.geyIndexCol("id"));
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

        





        //-------------------------------------------------------------------

        /**


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
            Table loadedTable = Table.load("tablaTest.txt");

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

            Table loadedTable = Table.load("tablaTest.txt");
            Assert.AreEqual(2, loadedTable.getNumRow());

        }
    **/

    }
}
