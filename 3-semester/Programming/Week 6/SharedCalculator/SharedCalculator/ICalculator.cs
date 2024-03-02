namespace SharedCalculator;

/// <summary>
/// Represents a calculator interface.
/// </summary>
public interface ICalculator
{
    /// <summary>
    /// Adds two numbers.
    /// </summary>
    /// <param name="a">The first number.</param>
    /// <param name="b">The second number.</param>
    /// <returns>The sum of the two numbers.</returns>
    double Add(double a, double b);

    /// <summary>
    /// Subtracts two numbers.
    /// </summary>
    /// <param name="a">The first number.</param>
    /// <param name="b">The second number.</param>
    /// <returns>The difference between the two numbers.</returns>
    double Subtract(double a, double b);

    /// <summary>
    /// Multiplies two numbers.
    /// </summary>
    /// <param name="a">The first number.</param>
    /// <param name="b">The second number.</param>
    /// <returns>The product of the two numbers.</returns>
    double Multiply(double a, double b);

    /// <summary>
    /// Divides two numbers.
    /// </summary>
    /// <param name="a">The first number.</param>
    /// <param name="b">The second number.</param>
    /// <returns>The quotient of the two numbers.</returns>
    double Divide(double a, double b);
}
