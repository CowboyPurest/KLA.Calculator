using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KLA.Calculator.Services;
using KLA.Calculator.Services.Contracts;

namespace KLA.Calculator.Web.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly ICalculatorService _calculatorService;
        public CalculatorController(ICalculatorService calculatorService)
        {
             this._calculatorService = new CalculatorService();
        }
        
        // GET: Calculator
        public PartialViewResult Calculate()
        {
            return this.PartialView(0.00);
        }

        [HttpPost]
        public PartialViewResult Calculate(string expression)
        {
            var result = this._calculatorService.CalculateExpression(expression);
            return PartialView(result);
        }
    }
}