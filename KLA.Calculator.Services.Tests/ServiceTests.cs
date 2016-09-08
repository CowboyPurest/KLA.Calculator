using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace KLA.Calculator.Services.Tests
{
    public class ServiceTests
    {

         [Theory(DisplayName = "Calculation Int Test") ]
         [InlineData("4+4", 8)] 
         [InlineData("5+5", 10)]
         [InlineData("25/5", 5)]  
         [InlineData("5*5", 25)]  
         [InlineData("(4.0+4.0)*2", 16)]

        public void IntCalculatorTest(string expression, int expected)
         {
            var calculator = new CalculatorService();
            var result = calculator.CalculateExpression(expression);
            Assert.Equal(expected, result);
        }


        [Theory(DisplayName = "Calculation Double Test")]
        [InlineData("4+4*2", 12.0)]
        [InlineData("1/4", .25)]
        [InlineData("1/2", .5)] 
        public void CalculatorDoubleTest(string expression, double expected)
        {
            var calculator = new CalculatorService();
           var result = calculator.CalculateExpression(expression);
            Assert.Equal(expected, result);
        }

        [Theory(DisplayName = "Calculation Divid by Test")]
        [InlineData("1/0")]
        [InlineData("2/0")]
        public void CalculatorDividByZero(string expression)
        {
            var calculator = new CalculatorService();
            var result = calculator.CalculateExpression(expression);
            Assert.Equal(result, Double.PositiveInfinity);
        }


    }



}
