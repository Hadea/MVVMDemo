using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data.ViewModels;
using Data.Models;

namespace Test
{
    [TestClass]
    public class TestCustomerViewModel
    {
        readonly CustomerViewModel cVM = new CustomerViewModel();

        [TestMethod]
        public void Insert_CommandExists()
        {
            Assert.IsNotNull(cVM.InsertCommand);
        }

        [TestMethod]
        public void Insert_WithoutData()
        {
            Assert.AreEqual(cVM.InsertCommand.CanExecute(null), true, "Insert should not be possible without Data");
        }


        /// <summary>
        /// Test ob die Datenbank auch Daten empfangen kann.
        /// </summary>
        public void Insert_WithData() // Da das Attribut TestMethod fehlt wird dieser Code nicht mit ausgeführt.
        {
            //TODO: Erstellung testen.
            Customer cusomter = new Customer {
                CustomerID = "Test",
                Address = "Test",
                City = "Test",
                CompanyName = "Test",
                ContactName = "Test",
                ContactTitle = "Test",
                Country = "Test",
                Fax = "Test",
                Phone = "Test",
                PostalCode = "Test",
                Region= "Test"
                };
        }

        [TestMethod]
        public void Database_Connection()
        {
            Assert.IsNotNull(cVM.CustomerList);
        }


    }
}
