using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Web.Controllers;
using Web.Infrastructure;
using System.Configuration;
using Web.ViewModels;
using ReportsOrder;
using System.Collections.Generic;

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
            
            IOrderService data = Factory.CreateOrderService(Web.Infrastructure.Factory.ReportType.Word);

            Assert.IsNotNull(data);

            CompanyOrders _companyOrders = data.GetCompanyOrders(Factory.CreateCompanyOrdersRepository(Factory.DBAccessType.SQL), 1);
            
            //_companyOrders = Factory.CreateCompanyOrdersRepository(Factory.DBAccessType.SQL).GetCompany(1);

            Assert.IsNotNull(_companyOrders);

            Assert.AreEqual(1, _companyOrders.Company.CompanyId);
            
            var convertCompany = Factory.CreateSQLDataAccess(Factory.DBAccessType.SQL).GetCompany(ConfigurationManager.ConnectionStrings["BrainWareConnectionString"].ConnectionString, 1);

            Assert.IsNotNull(convertCompany);

            Assert.IsTrue(true);
        }


        [TestMethod]
        public void TestEF()
        {

            IOrderService data = Factory.CreateOrderService(Web.Infrastructure.Factory.ReportType.TXT);

            Assert.IsNotNull(data);

            ICompanyOrdersRepository CompanyOrders = new CompanyOrdersRepository(Factory.DBAccessType.EF);

            CompanyOrders _companyOrders = data.GetCompanyOrders(Factory.CreateCompanyOrdersRepository(Factory.DBAccessType.EF), 1);

            //CompanyOrders _companyOrders = CompanyOrders.GetCompany(1);

            Assert.IsNotNull(_companyOrders);

            Assert.AreEqual(1, _companyOrders.Company.CompanyId);

            var convertCompany = Factory.CreateSQLDataAccess(Factory.DBAccessType.EF).GetCompany(ConfigurationManager.ConnectionStrings["BrainWareConnectionString"].ConnectionString, 1);

            Assert.IsNotNull(convertCompany);

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestDapper()
        {

            IOrderService data = Factory.CreateOrderService(Web.Infrastructure.Factory.ReportType.PDF);

            Assert.IsNotNull(data);

            ICompanyOrdersRepository CompanyOrders = new CompanyOrdersRepository(Factory.DBAccessType.Dapper);

            CompanyOrders _companyOrders = data.GetCompanyOrders(Factory.CreateCompanyOrdersRepository(Factory.DBAccessType.Dapper), 1);

            //CompanyOrders _companyOrders = CompanyOrders.GetCompany(1);

            Assert.IsNotNull(_companyOrders);

            Assert.AreEqual(1, _companyOrders.Company.CompanyId);
            
            var convertCompany = Factory.CreateSQLDataAccess(Factory.DBAccessType.Dapper).GetCompany(ConfigurationManager.ConnectionStrings["BrainWareConnectionString"].ConnectionString, 1);

            Assert.IsNotNull(convertCompany);

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestReportPDF()
        {
            
            ReportsOrder.R_iTextSharp testreport = new ReportsOrder.R_iTextSharp();
            List<string> ReportStrings = new List<string>();

            ReportStrings.Add("Company ID: " + "1");
            ReportStrings.Add("Company Name: " + "Company Name");

            string doclocation = testreport.CreateDoc(ReportStrings, "", "H:\\TestReports\\");            

            Assert.IsTrue(true);
        }
        
        [TestMethod]
        public void TestReportWord()
        {

            ReportsOrder.R_Word testreport = new ReportsOrder.R_Word();
            List<string> ReportStrings = new List<string>();

            ReportStrings.Add("Company ID: " + "1");
            ReportStrings.Add("Company Name: " + "Company Name");

            string doclocation = testreport.CreateDoc(ReportStrings, "", "H:\\TestReports\\");

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestReportText()
        {

            ReportsOrder.R_Text testreport = new ReportsOrder.R_Text();
            List<string> ReportStrings = new List<string>();

            ReportStrings.Add("Company ID: " + "1");
            ReportStrings.Add("Company Name: " + "Company Name");

            string doclocation = testreport.CreateDoc(ReportStrings, "", "H:\\TestReports\\");

            Assert.IsTrue(true);
        }

    }
}
