namespace CalculatorApp;

public class OutputHandler
{
    public void PrintResult(double result)
    {
        Console.WriteLine($"The result is: {result}");
    }

    public void PrintError(string message)
    {
        Console.WriteLine($"An error occurred: {message}");
    }

    public void PrintWelcomeMessage()
    {
        Console.WriteLine("Welcome to the calculator app!");
    }

    public void PrintGoodbyeMessage()
    {
        Console.WriteLine("Goodbye!");
    }

    public void PrintContinue()
    {
        Console.WriteLine("Do you want to continue? (y/n)");
    }
}
