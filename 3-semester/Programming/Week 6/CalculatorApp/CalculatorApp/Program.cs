namespace CalculatorApp;

class Program
{
    static void Main(string[] args)
    {
        CalculatorApp calculatorApp = new CalculatorApp();
        calculatorApp.Run().Wait();
    }
}