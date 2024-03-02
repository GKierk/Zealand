using SharedCalculator;

namespace CalculatorApp;

public class InputHandler
{
    Calculator calculator = new Calculator();

    public async Task<double> Operation()
    {
        char operation;
        double result;
        List<double> numbers = new List<double>();

        Console.WriteLine("Enter what you wish to calculate: ");
        string input = Console.ReadLine() ?? string.Empty;

        numbers = await Task.Run(() => ProcessNumbers(input));
        operation = await Task.Run(() => ProcessOperand(input));

        result = operation switch
        {
            '+' => calculator.Add(numbers[0], numbers[1]),
            '-' => calculator.Subtract(numbers[0], numbers[1]),
            '*' => calculator.Multiply(numbers[0], numbers[1]),
            '/' => calculator.Divide(numbers[0], numbers[1]),
            _ => throw new InvalidOperationException("Invalid operation")
        };

        return result;
    }

    public List<double> ProcessNumbers(string numbers)
    {
        return numbers.Split('+', '-', '*', '/').Select(double.Parse).ToList();
    }

    public char ProcessOperand(string input)
    {
        return input.Where(c => c == '+' || c == '-' || c == '*' || c == '/').First();
    }
}
