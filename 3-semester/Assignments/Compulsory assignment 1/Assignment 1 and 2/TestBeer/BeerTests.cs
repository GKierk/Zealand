namespace Drinks.Tests;

[TestClass]
public class BeerTests
{
    [TestMethod]
    public void BeerPropertiesTest()
    {
        Beer beer = new Beer() { Id = 1, Name = "Carlsberg", Abv = 5 };

        Assert.AreEqual(1, beer.Id);
        Assert.AreEqual("Carlsberg", beer.Name);
        Assert.AreEqual(5, beer.Abv);
    }

    [TestMethod]
    public void ValidateIdTest()
    {
        var beer = new Beer() { Id = 1 };

        var result = beer.ValidateId(beer.Id);

        Assert.IsTrue(result);
    }

    [TestMethod]
    public void ValidateIdExceptionTest()
    {
        var beer = new Beer();
        int invalidId = -1;

        Assert.ThrowsException<ArgumentOutOfRangeException>(() => beer.ValidateId(invalidId));
    }

    [TestMethod]
    public void ValidateNameTest()
    {
        var beer = new Beer();
        string validName = "Carlsberg";

        var result = beer.ValidateName(validName);

        Assert.IsTrue(result);
    }

    [TestMethod]
    public void ValidateNameExceptionTest()
    {
        var beer = new Beer();
        string invalidName = "C";

        Assert.ThrowsException<ArgumentException>(() => beer.ValidateName(invalidName));
    }

    [TestMethod]
    public void VaidateAbvTest()
    {
        var beer = new Beer();
        double validAbv = 5;

        var result = beer.ValidateAbv(validAbv);

        Assert.IsTrue(result);
    }

    [TestMethod]
    public void ValidateAbvExceptionTest()
    {
        var beer = new Beer();
        double invalidAbv = 70;

        Assert.ThrowsException<ArgumentOutOfRangeException>(() => beer.ValidateAbv(invalidAbv));
    }
}
