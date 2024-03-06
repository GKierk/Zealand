namespace ActorRepositoryLib.Tests;

[TestClass]
public class ActorTests
{
    [TestMethod]
    public void ValidateId_ValidId_ReturnsTrue()
    {
        var actor = new Actor();
        actor.Id = 1;

        var result = actor.ValidateId();

        Assert.IsTrue(result);
    }

    [TestMethod]
    public void ValidateId_InvalidId_ThrowsArgumentException()
    {
        var actor = new Actor();
        actor.Id = 0;

        Assert.ThrowsException<ArgumentException>(() => actor.ValidateId());
    }

    [TestMethod]
    public void ValidateName_ValidName_ReturnsTrue()
    {
        var actor = new Actor();
        actor.Name = "John Doe";

        var result = actor.ValidateName();

        Assert.IsTrue(result);
    }

    [TestMethod]
    public void ValidateName_NullName_ThrowsArgumentException()
    {
        var actor = new Actor();
        actor.Name = null;

        Assert.ThrowsException<ArgumentException>(() => actor.ValidateName());
    }

    [TestMethod]
    public void ValidateName_EmptyName_ThrowsArgumentException()
    {
        var actor = new Actor();
        actor.Name = "";

        Assert.ThrowsException<ArgumentException>(() => actor.ValidateName());
    }

    [TestMethod]
    public void ValidateName_ShortName_ThrowsArgumentException()
    {
        var actor = new Actor();
        actor.Name = "Jo";

        Assert.ThrowsException<ArgumentException>(() => actor.ValidateName());
    }

    [TestMethod]
    public void ValidateBirthYear_ValidBirthYear_ReturnsTrue()
    {
        var actor = new Actor();
        actor.BirthYear = 1990;

        var result = actor.ValidateBirthYear();

        Assert.IsTrue(result);
    }

    [TestMethod]
    public void ValidateBirthYear_InvalidBirthYear_ThrowsArgumentException()
    {
        var actor = new Actor();
        actor.BirthYear = 1800;

        Assert.ThrowsException<ArgumentException>(() => actor.ValidateBirthYear());
    }
}
