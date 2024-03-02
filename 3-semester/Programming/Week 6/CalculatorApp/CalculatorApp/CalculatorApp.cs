namespace CalculatorApp;

public class CalculatorApp
{
    private static CalculatorApp? instance;
    private static readonly object lockThread = new object();

    InputHandler inputHandler = new InputHandler();
    OutputHandler outputHandler = new OutputHandler();

    public static async Task<CalculatorApp> GetInstance()
    {
        if (instance == null)
        {
            lock (lockThread)
            {
                if (instance == null)
                {
                    instance = new CalculatorApp();
                }
            }
        }

        await Task.Yield();

        return instance;
    }

    public async Task Run()
    {
        outputHandler.PrintWelcomeMessage();

        do
        {
            double result = await inputHandler.Operation();
            outputHandler.PrintResult(result);
            outputHandler.PrintContinue();
        } while (Console.ReadLine()?.ToLower() == "y");

        outputHandler.PrintGoodbyeMessage();
    }
}
