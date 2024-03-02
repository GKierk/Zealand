namespace SharedCalculator;

/// <summary>
/// Represents a calculator that performs basic arithmetic operations.
/// </summary>
public class Calculator : ICalculator
{
    /// <summary>
    /// Adds two numbers.
    /// </summary>
    /// <param name="a">The first number.</param>
    /// <param name="b">The second number.</param>
    /// <returns>The sum of the two numbers.</returns>
    public double Add(double a, double b)
    {
        return a + b;
    }

    /// <summary>
    /// Divides two numbers.
    /// </summary>
    /// <param name="a">The dividend.</param>
    /// <param name="b">The divisor.</param>
    /// <returns>The quotient of the division.</returns>
    public double Divide(double a, double b)
    {
        return a / b;
    }

    /// <summary>
    /// Multiplies two numbers.
    /// </summary>
    /// <param name="a">The first number.</param>
    /// <param name="b">The second number.</param>
    /// <returns>The product of the two numbers.</returns>
    public double Multiply(double a, double b)
    {
        return a * b;
    }

    /// <summary>
    /// Subtracts two numbers.
    /// </summary>
    /// <param name="a">The minuend.</param>
    /// <param name="b">The subtrahend.</param>
    /// <returns>The difference between the two numbers.</returns>
    public double Subtract(double a, double b)
    {
        return a - b;
    }
}
