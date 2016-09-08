using KLA.Calculator.Services;
using KLA.Calculator.Services.Contracts;
using System;
using System.Net;
using System.Web.Mvc;

namespace KLA.Calculator.Web.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly ICalculatorService _calculatorService;

        public CalculatorController(ICalculatorService calculatorService)
        {
            this._calculatorService = new CalculatorService();
        }

        [ChildActionOnly]
        // GET: Calculator
        public PartialViewResult Calculate()
        {
            return this.PartialView();
        }

        [HttpPost]
        public JsonResult Calculate(string expression)
        {
            try
            {
                var result = this._calculatorService.CalculateExpression(expression);
                if (double.IsPositiveInfinity(result) || double.IsNegativeInfinity(result)) throw new Exception("Divid by zero");

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json("Please check your entry for errors");
            }
        }
    }
}