using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Web.Controllers;
using Web.Infrastructure;
using System.Configuration;
using Web.ViewModels;

namespace Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Order Page", result.ViewBag.Title);
        }

        [TestMethod]
        public void TestSQL()
        {
            
            IOrderService data = Factory.CreateOrderService();

            Assert.IsNotNull(data);
            
            CompanyOrders _companyOrders = Factory.CreateCompanyOrdersRepository(Factory.DBAccessType.SQL).GetCompany(1);

            Assert.IsNotNull(_companyOrders);

            Assert.AreEqual(1, _companyOrders.Company.CompanyId);
            
            var convertCompany = Factory.CreateSQLDataAccess(Factory.DBAccessType.SQL).GetCompany(ConfigurationManager.ConnectionStrings["BrainWareConnectionString"].ConnectionString, 1);

            Assert.IsNotNull(convertCompany);

            Assert.IsTrue(true);
        }


        [TestMethod]
        public void TestEF()
        {

            IOrderService data = Factory.CreateOrderService();

            Assert.IsNotNull(data);

            ICompanyOrdersRepository CompanyOrders = new CompanyOrdersRepository(Factory.DBAccessType.EF);

            CompanyOrders _companyOrders = CompanyOrders.GetCompany(1);

            Assert.IsNotNull(_companyOrders);

            Assert.AreEqual(1, _companyOrders.Company.CompanyId);

            var convertCompany = Factory.CreateSQLDataAccess(Factory.DBAccessType.EF).GetCompany(ConfigurationManager.ConnectionStrings["BrainWareConnectionString"].ConnectionString, 1);

            Assert.IsNotNull(convertCompany);

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestDapper()
        {

            IOrderService data = Factory.CreateOrderService();

            Assert.IsNotNull(data);

            ICompanyOrdersRepository CompanyOrders = new CompanyOrdersRepository(Factory.DBAccessType.Dapper);

            CompanyOrders _companyOrders = CompanyOrders.GetCompany(1);

            Assert.IsNotNull(_companyOrders);

            Assert.AreEqual(1, _companyOrders.Company.CompanyId);

            var convertCompany = Factory.CreateSQLDataAccess(Factory.DBAccessType.Dapper).GetCompany(ConfigurationManager.ConnectionStrings["BrainWareConnectionString"].ConnectionString, 1);

            Assert.IsNotNull(convertCompany);

            Assert.IsTrue(true);
        }

    }
}
