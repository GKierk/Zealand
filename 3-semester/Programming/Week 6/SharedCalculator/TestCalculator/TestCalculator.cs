using SharedCalculator;

namespace TestCalculator;

[TestClass]
public class TestCalculator
{
    [TestMethod]
    public void TestAddition()
    {
        ICalculator calculator = new Calculator();

        double result = calculator.Add(10, 20);

        Assert.AreEqual(30, result);
    }

    [TestMethod]
    public void TestSubtraction()
    {
        ICalculator calculator = new Calculator();

        double result = calculator.Subtract(20, 10);

        Assert.AreEqual(10, result);
    }

    [TestMethod]
    public void TestMultiplication()
    {
        ICalculator calculator = new Calculator();

        double result = calculator.Multiply(10, 20);

        Assert.AreEqual(200, result);
    }

    [TestMethod]
    public void TestDivision()
    {
        ICalculator calculator = new Calculator();

        double result = calculator.Divide(20, 10);

        Assert.AreEqual(2, result);
    }
}