using Microsoft.VisualStudio.TestTools.UnitTesting;
using Beer;
using System;

namespace Beer.Tests;

[TestClass]
public class TestBeers
{
    [TestMethod]
    public void TestBeerProperties()
    {
        var beer = new Beer();
        beer.Id = 1;
        beer.Name = "Carlsberg";
        beer.Abv = 5;

        var id = beer.Id;
        var name = beer.Name;
        var abv = beer.Abv;

        Assert.AreEqual(1, id);
        Assert.AreEqual("Carlsberg", name);
        Assert.AreEqual(5, abv);
    }

    [TestMethod]
    public void TestValidateId()
    {
        var beer = new Beer();
        int? validId = 1;

        var result = beer.ValidateId(validId);

        Assert.IsTrue(result);
    }

    [TestMethod]
    public void TestValidateIdException()
    {
        var beer = new Beer();
        int? invalidId = -1;

        Assert.ThrowsException<ArgumentOutOfRangeException>(() => beer.ValidateId(invalidId));
    }

    [TestMethod]
    public void TestValidateName()
    {
        var beer = new Beer();
        string validName = "Carlsberg";

        var result = beer.ValidateName(validName);

        Assert.IsTrue(result);
    }

    [TestMethod]
    public void TestValidateNameException()
    {
        var beer = new Beer();
        string invalidName = "C";

        Assert.ThrowsException<ArgumentException>(() => beer.ValidateName(invalidName));
    }

    [TestMethod]
    public void TestVaidateAbv()
    {
        var beer = new Beer();
        double? validAbv = 5;

        var result = beer.ValidateAbv(validAbv);

        Assert.IsTrue(result);
    }

    [TestMethod]
    public void TestValidateAbvException()
    {
        var beer = new Beer();
        double? invalidAbv = 70;

        Assert.ThrowsException<ArgumentOutOfRangeException>(() => beer.ValidateAbv(invalidAbv));
    }
}
