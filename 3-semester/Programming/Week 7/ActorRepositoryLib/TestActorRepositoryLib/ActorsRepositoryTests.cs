namespace ActorRepositoryLib.Tests;

[TestClass]
public class ActorsRepositoryTests
{
    // TODO: Rewrite Tests

    //[TestMethod]
    //public void Get_NoParameters_ReturnsAllActors()
    //{
    //    var repository = new ActorsRepository();
    //    var actor1 = new Actor
    //    {
    //        Name = "John Doe",
    //        BirthYear = 1990
    //    };
    //    var actor2 = new Actor
    //    {
    //        Name = "Jane Smith",
    //        BirthYear = 1985
    //    };

    //    repository.AddActor(actor1);
    //    repository.AddActor(actor2);

    //    var result = repository.Get();

    //    Assert.IsNotNull(result);
    //    CollectionAssert.Contains(result.ToList(), actor1);
    //    CollectionAssert.Contains(result.ToList(), actor2);
    //}

    //[TestMethod]
    //public void Get_WithParameters_ReturnsFilteredActors()
    //{
    //    var repository = new ActorsRepository();
    //    var actor1 = new Actor
    //    {
    //        Name = "John Doe",
    //        BirthYear = 1990
    //    };
    //    var actor2 = new Actor
    //    {
    //        Name = "Jane Smith",
    //        BirthYear = 1985
    //    };

    //    repository.AddActor(actor1);
    //    repository.AddActor(actor2);

    //    var result = repository.Get(birthYearYearBefore: 1990, birthYearAfter: 1985, name: "John Doe");

    //    Assert.IsNotNull(result);
    //    CollectionAssert.Contains(result.ToList(), actor1);
    //}

    //[TestMethod]
    //public void Get_WithParameters_ReturnsSortedActors()
    //{
    //    var repository = new ActorsRepository();
    //    var actor1 = new Actor
    //    {
    //        Name = "John Doe",
    //        BirthYear = 1990
    //    };
    //    var actor2 = new Actor
    //    {
    //        Name = "Jane Smith",
    //        BirthYear = 1985
    //    };

    //    repository.AddActor(actor1);
    //    repository.AddActor(actor2);

    //    var result = repository.Get(birthYearYearBefore: 1990, birthYearAfter: 1985, sortOrder: "name_desc");

    //    Assert.IsNotNull(result);
    //    CollectionAssert.Contains(result.ToList(), actor2);
    //}

    //[TestMethod]
    //public void Get_InvalidParameters_ThrowsArgumentException()
    //{
    //    var repository = new ActorsRepository();

    //    Assert.ThrowsException<ArgumentException>(() => repository.Get(birthYearYearBefore: 1985, birthYearAfter: 1990));
    //}

    //[TestMethod]
    //public void AddActor_ValidActor_ReturnsAddedActor()
    //{
    //    var repository = new ActorsRepository();
    //    var actor = new Actor
    //    {
    //        Name = "John Doe",
    //        BirthYear = 1990
    //    };

    //    var result = repository.AddActor(actor);

    //    Assert.IsNotNull(result);
    //    Assert.AreEqual(actor, result);
    //}

    //[TestMethod]
    //public void AddActor_NullActor_ThrowsArgumentNullException()
    //{
    //    var repository = new ActorsRepository();

    //    Assert.ThrowsException<ArgumentNullException>(() => repository.AddActor(null!));
    //}

    //[TestMethod]
    //public void Delete_ValidId_ReturnsDeletedActor()
    //{
    //    var repository = new ActorsRepository();
    //    var actor1 = new Actor
    //    {
    //        Name = "John Doe",
    //        BirthYear = 1990
    //    };
    //    var actor2 = new Actor
    //    {
    //        Name = "Jane Smith",
    //        BirthYear = 1985
    //    };

    //    repository.AddActor(actor1);
    //    repository.AddActor(actor2);

    //    var result = repository.Delete(actor1.Id);

    //    Assert.IsNotNull(result);
    //    Assert.AreEqual(actor1, result);
    //    CollectionAssert.DoesNotContain(repository.Get().ToList(), actor1);
    //}

    //[TestMethod]
    //public void Delete_InvalidId_ThrowsArgumentOutOfRangeException()
    //{
    //    var repository = new ActorsRepository();

    //    Assert.ThrowsException<ArgumentOutOfRangeException>(() => repository.Delete(0));
    //}

    //[TestMethod]
    //public void Update_ValidIdAndActor_ReturnsUpdatedActor()
    //{
    //    var repository = new ActorsRepository();
    //    var actor1 = new Actor
    //    {
    //        Name = "John Doe",
    //        BirthYear = 1990
    //    };
    //    var actor2 = new Actor
    //    {
    //        Name = "Jane Smith",
    //        BirthYear = 1985
    //    };

    //    repository.AddActor(actor1);
    //    repository.AddActor(actor2);

    //    var updatedActor = new Actor
    //    {
    //        Id = actor1.Id,
    //        Name = "Jane Smith",
    //        BirthYear = 1985
    //    };

    //    var result = repository.Update(actor1.Id, updatedActor);

    //    Assert.IsNotNull(result);
    //    Assert.AreEqual(updatedActor, result);
    //    CollectionAssert.Contains(repository.Get().ToList(), updatedActor);
    //}

    //[TestMethod]
    //public void Update_InvalidId_ThrowsArgumentOutOfRangeException()
    //{
    //    var repository = new ActorsRepository();
    //    var actor = new Actor
    //    {
    //        Name = "John Doe",
    //        BirthYear = 1990
    //    };
    //    repository.AddActor(actor);

    //    var updatedActor = new Actor
    //    {
    //        Id = actor.Id,
    //        Name = "Jane Smith",
    //        BirthYear = 1985
    //    };

    //    Assert.ThrowsException<ArgumentOutOfRangeException>(() => repository.Update(10, updatedActor));
    //}
}
