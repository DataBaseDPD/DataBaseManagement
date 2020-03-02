using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataBaseDPD;


namespace TestDataBase
{
    [TestClass]
    public class UnitTestTable
    {
       

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
            
        }
        [TestMethod]
        public void LoadEmptyTableTest()
        {
            Table table = new Table("tablaVacia.txt");
            table.save("tablaVacia.txt");

            Assert.AreEqual(0, table.getNumRow());
        }
        [TestMethod]
        public void getNumRowTest()
        {

        }
        [TestMethod]
        public void addTupleTest()
        {
            Table tabla = new Table("tablaTest.txt");

            TableRow tuple = new TableRow();
            tuple.add(new string[] { "1", "david", "david@email.com" });
            tabla.addRow(tuple);
            tabla.save("tablaTest.txt");

            Table tabTest = Table.load("tablaTest.txt");
            Assert.AreEqual(tabTest.getNumRow(), tabla.getNumRow());

            
        }
        [TestMethod]
        public void getTupleTest()
        {
            Table tabla = new Table("tablaTest.txt");
            TableRow tuple1 = new TableRow();
            tuple1.add(new string[] { "1", "david", "david@email.com" });
            tabla.addRow(tuple1);
            tabla.save("tablaTest.txt");

            //Falta implementar
        }
        [TestMethod]
        public void getFirstTupleTest()
        {
            Table tabla = new Table("tablaTest.txt");
            TableRow tuple1 = new TableRow();
            tuple1.add(new string[] { "1", "david", "david@email.com" });
            TableRow tuple2 = new TableRow();
            tuple2.add(new string[] { "2", "percy", "percy@email.com" });
            tabla.addRow(tuple1);
            tabla.addRow(tuple2);
            tabla.save("tablaTest.txt");

            Table tabTest = Table.load("tablaTest.txt");
            TableRow tupleTest1 = tabTest.getFirstRow();
            Assert.isTrue(String.Equals(tupleTest1.getItem(1), tuple1.getItem(1)));
        }
        [TestMethod]
        public void getNextTupleTest()
        {
            Table tabla = new Table("tablaTest.txt");
            TableRow tuple1 = new TableRow();
            tuple1.add(new string[] { "1", "david", "david@email.com" });
            TableRow tuple2 = new TableRow();
            tuple2.add(new string[] { "2", "percy", "percy@email.com" });
            tabla.addRow(tuple1);
            tabla.addRow(tuple2);
            tabla.save("tablaTest.txt");

            Table tabTest = Table.load("tablaTest.txt");
            TableRow tupleTest1 = tabTest.getFirstRow();
            bool check1 = String.Equals(tupleTest1.getItem(1), tuple1.getItem(1));
            TableRow tupleTest2 = tabTest.getNextRow();
            bool check2 = String.Equals(tupleTest2.getItem(1), tuple2.getItem(1));

            Assert.isTrue(check1&&check2);
        }
        
        
    }
}
