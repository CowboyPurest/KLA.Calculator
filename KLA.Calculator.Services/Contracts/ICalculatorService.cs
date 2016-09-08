namespace KLA.Calculator.Services.Contracts
{
    public interface ICalculatorService
    {
        double CalculateExpression(string expression);

        void Dispose();
    }
}