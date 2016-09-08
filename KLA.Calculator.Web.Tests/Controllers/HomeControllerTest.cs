
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KLA.Calculator.Web;
using KLA.Calculator.Web.Controllers;

namespace KLA.Calculator.Web.Tests.Controllers
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
        }
        
    }
}
