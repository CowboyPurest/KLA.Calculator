using KLA.Calculator.Services;
using KLA.Calculator.Services.Contracts;
using KLA.Calculator.Web.Controllers;
using Xunit;

namespace KLA.Calculator.Web.Tests.Controllers
{
    public class CalculatorControllerTests
    {
        [Theory]
        [InlineData("4+4", 8)]
        [InlineData("4-4", 0)]
        [InlineData("4*4", 16)]
        [InlineData("4/4", 1)]
        [InlineData("4.0/4", 1)]

        public void CalculatePostTest(string expression, double expexted)
        {
            ICalculatorService calcservice = new CalculatorService();
            // Arrange
            var controller = new CalculatorController(calcservice);

            // Act
            var result = controller.Calculate(expression);

            var model = result.Model;

            //Assert that a double is returned
            Assert.IsType<double>(model);

            // Assert that a view is returned
            Assert.NotNull(result);
        }

        [Fact]
        public void CalculateGetTest()
        {
            ICalculatorService calcservice = new CalculatorService();
            // Arrange
            var controller = new CalculatorController(calcservice);

            // Act
            var result = controller.Calculate();

            // Assert
            Assert.NotNull(result);
        }
    }
}