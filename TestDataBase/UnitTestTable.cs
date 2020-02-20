using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataBaseDPD;


namespace TestDataBase
{
    [TestClass]
    public class UnitTestTable
    {
       

        [TestMethod]
        public void TestCreat()
        {
            Table tabla = new Table("tablaTest");
            Assert.IsNull(tabla);
        }
        [TestMethod]
        public void LoadEmptyTable()
        {
            Table table = Table.load("tablaTest");

            Assert.AreEqual(0, table.getNumRow());
        }
    }
}
