using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataBaseDPD;


namespace TestDataBase
{
    [TestClass]
    public class UnitTestTable
    {
       
        /**
        [TestMethod]
        public void creatTableTest()
        {
            Table tabla = new Table("tablaTest.txt");
            tabla.save("tablaTest.txt");
            Assert.IsNotNull(tabla);
        }
        [TestMethod]
        public void LoadTableTest()
        {
            Table tabla = new Table("tablaTest.txt");

            TableRow tuple = new TableRow(new string[] { "1", "david", "david@email.com" });
            tabla.addRow(tuple);
            tabla.save("tablaTest.txt");

            Table loadedTable = Table.load("tablaTest.txt");
            Assert.AreEqual(1, loadedTable.getNumRow());

        }
        [TestMethod]
        public void LoadEmptyTableTest()
        {
            Table table = new Table("tablaVacia.txt");
            table.save("tablaVacia.txt");

            Assert.AreEqual(0, table.getNumRow());
        }
        [TestMethod]
        public void addTupleTest()
        {
            Table tabla = new Table("tablaTest.txt");

            TableRow tuple = new TableRow(new string[] { "1", "david", "david@email.com" });
            tabla.addRow(tuple);
            tabla.save("tablaTest.txt");

            Table tabTest = Table.load("tablaTest.txt");
            Assert.AreEqual(tabTest.getNumRow(), tabla.getNumRow());

            
        }
        [TestMethod]
        public void getTupleTest()
        {
            Table tabla = new Table("tablaTest.txt");
            TableRow tuple1 = new TableRow(new string[] { "1", "david", "david@email.com" });
            tabla.addRow(tuple1);
            tabla.save("tablaTest.txt");

            TableRow tupleTest = Table.load("tablaTest.txt").getRow();
            bool check1 = String.Equals(tupleTest.getItem(1), tuple1.getItem(1));
            bool check2 = String.Equals(tupleTest.getItem(2), tuple1.getItem(2));

            Assert.IsTrue(check1 && check2);
        }
        [TestMethod]
        public void getFirstTupleTest()
        {
            Table tabla = new Table("tablaTest.txt");
            TableRow tuple1 = new TableRow(new string[] { "1", "david", "david@email.com" });
            TableRow tuple2 = new TableRow(new string[] { "2", "percy", "percy@email.com" });
            tabla.addRow(tuple1);
            tabla.addRow(tuple2);
            tabla.save("tablaTest.txt");

            Table tabTest = Table.load("tablaTest.txt");
            TableRow tupleTest1 = tabTest.getFirstRow();
            Assert.IsTrue(String.Equals(tupleTest1.getItem(1), tuple1.getItem(1)));
        }
        [TestMethod]
        public void getNextTupleTest()
        {
            Table tabla = new Table("tablaTest.txt");
            TableRow tuple1 = new TableRow(new string[] { "1", "david", "david@email.com" });
            TableRow tuple2 = new TableRow(new string[] { "2", "percy", "percy@email.com" });
            tabla.addRow(tuple1);
            tabla.addRow(tuple2);
            tabla.save("tablaTest.txt");

            Table tabTest = Table.load("tablaTest.txt");
            TableRow tupleTest1 = tabTest.getFirstRow();
            bool check1 = String.Equals(tupleTest1.getItem(1), tuple1.getItem(1));
            TableRow tupleTest2 = tabTest.nextRow();
            bool check2 = String.Equals(tupleTest2.getItem(1), tuple2.getItem(1));

            Assert.IsTrue(check1&&check2);
        } 
        [TestMethod]
        public void getNumColumTest()
        {
            Table table = new Table("tablaTest.txt");
            TableRow tuple = new TableRow(new string[] { "1", "david", "david@email.com"});
            table.addRow(tuple);
            table.save("tablaTest.txt");

            Table tabTest = Table.load("tablaTest.txt");

            Assert.AreEqual(3, tabTest.getNumColumn());
        }
        [TestMethod]
        public void getNumRowTest()
        {
        Table table = new Table("tablaTest.txt");
        TableRow tuple = new TableRow(new string[] { "1", "david", "david@email.com" });
        TableRow tuple2 = new TableRow(new string[] { "2", "percy", "percy@email.com" });
        TableRow tuple3 = new TableRow(new string[] { "3", "domenico", "domenico@email.com" });
        table.addRow(tuple);
        table.addRow(tuple2);
        table.addRow(tuple3);
        table.save("tablaTest.txt");

        Table tabTest = Table.load("tablaTest.txt");


        Assert.AreEqual(3,tabTest.getNumRow());
        }
    **/
    }
}
