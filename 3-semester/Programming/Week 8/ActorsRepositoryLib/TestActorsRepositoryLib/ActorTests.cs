namespace ActorRepositoryLib.Tests;

[TestClass]
public class ActorTests
{
    [TestMethod]
    public void ToString_ReturnsFormattedString()
    {
        Actor actor = new Actor
        {
            Id = 1,
            Name = "Tom Hanks",
            BirthYear = 1956
        };

        string result = actor.ToString();

        Assert.AreEqual("1: Tom Hanks (1956)", result);
    }

    [TestMethod]
    public void ValidateName_ValidName_ReturnsTrue()
    {
        Actor actor = new Actor
        {
            Name = "Robert Downey Jr."
        };

        bool result = actor.ValidateName();

        Assert.IsTrue(result);
    }

    [TestMethod]
    public void ValidateName_InvalidName_ThrowsArgumentException()
    {
        Actor actor = new Actor
        {
            Name = "Bo"
        };

        Assert.ThrowsException<ArgumentException>(() => actor.ValidateName());
    }

    [TestMethod]
    public void ValidateBirthYear_ValidBirthYear_ReturnsTrue()
    {
        Actor actor = new Actor
        {
            BirthYear = 1980
        };

        bool result = actor.ValidateBirthYear();

        Assert.IsTrue(result);
    }

    [TestMethod]
    public void ValidateBirthYear_InvalidBirthYear_ThrowsArgumentException()
    {
        Actor actor = new Actor
        {
            Name = "Eric",
            BirthYear = 1800
        };

        Assert.ThrowsException<ArgumentException>(() => actor.ValidateBirthYear());
    }

    [TestMethod]
    public void Validate_ValidActor_ReturnsTrue()
    {
        Actor actor = new Actor
        {
            Name = "Leonardo DiCaprio",
            BirthYear = 1974
        };

        bool result = actor.Validate();

        Assert.IsTrue(result);
    }

    [TestMethod]
    public void Validate_InvalidActor_ThrowsArgumentException()
    {
        Actor actor = new Actor
        {
            Name = "Bo",
            BirthYear = 1800
        };

        Assert.ThrowsException<ArgumentException>(() => actor.Validate());
    }
}
