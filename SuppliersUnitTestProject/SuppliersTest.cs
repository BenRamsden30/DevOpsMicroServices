using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System;
using TheThreeAmigos.Models;

namespace SuppliersUnitTestProject
{
    [TestClass]
    public class SuppliersTest
    {
        [TestInitialize]
        public void initalizer ()
        {
                   Expected = new SuppliersModel() { SupplierId = "1", SupplierName = "Test", SupplierAddress = "42 Wallabe Way Sydney", SupplierEmail = "Test@The3Amigos.net", SupplierContactNumber = "01642012041" };
        }

        private SuppliersModel Expected;


        [TestMethod]
        public void TestViewIndex()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                SuppliersMicroservice.Program.SuppliersModelsController();

                var result = sw.ToString().Trim();
                Assert.AreEqual(Expected, result);

            }
        }
    }
}
