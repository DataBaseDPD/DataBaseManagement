using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataBaseDPD;


namespace TestDataBase
{
    [TestClass]
    public class UnitTestTable
    {
       

        [TestMethod]
        public void creatTable()
        {
            Table tabla = new Table("tablaTest");
            Assert.IsNotNull(tabla);
        }
        [TestMethod]
        public void LoadEmptyTable()
        {
            Table table = Table.load("tablaVacia");

            Assert.AreEqual(0, table.getNumRow());
        }
        [TestMethod]
        public void addTuple()
        {
            Table tabla = new Table("tablaTest");
            List<string> tuple = new List<string>(new string[] { "1", "david", "david@email.com" });

            tabla.addRow(tuple);
            
        }
        [TestMethod]
        public void getNextuple()
        {

        }
        [TestMethod]
        public void xxx()
        {

        }
        [TestMethod]
        public void addTuple()
        {

        }
        [TestMethod]
        public void addTuple()
        {

        }
        [TestMethod]
        public void addTuple()
        {

        }
    }
}
