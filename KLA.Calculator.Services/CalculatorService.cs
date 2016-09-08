using KLA.Calculator.Services.Contracts;
using System;
using System.Data;

namespace KLA.Calculator.Services
{
    public class CalculatorService : IDisposable, ICalculatorService
    {
        private DataTable _dataTable;

        public CalculatorService()
        {
            _dataTable = new DataTable();
        }

        public double CalculateExpression(string expression)
        {
            try
            {
                var result = this._dataTable.Compute(expression, null);
                return Convert.ToDouble(result); //cast the result to a double
            }
            catch (Exception)
            {
                throw new ArgumentException("The expression did not return something that could not be cast to a double");
            }
        }

        /// <summary>
        /// Dispose of the datatable to free resources
        /// </summary>
        public void Dispose()
        {
            this._dataTable.Dispose();
        }
    }
}