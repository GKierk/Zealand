using Microsoft.EntityFrameworkCore;

namespace ActorRepositoryLib.Tests;

[TestClass]
public class ActorsRepositoryTests
{
    private const bool useDatabase = true;
    private static ActorsDbContext? dbContext;
    private IActorsRepository? repo;

    [ClassInitialize]
    public static void ClassInitialize(TestContext testContext)
    {
        if (useDatabase)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ActorsDbContext>();
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Repository;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            dbContext = new ActorsDbContext(optionsBuilder.Options);
        }
    }

    [TestInitialize]
    public void Init()
    {
        //if (useDatabase)
        //{
        //    repo = new ActorsRepository(dbContext!);
        //    dbContext?.Database.ExecuteSqlRaw("Truncate Table dbo.Actors");
        //}

        repo = new ActorsRepository(dbContext!);
        dbContext?.Database.ExecuteSqlRaw("Truncate Table dbo.Actors");

        repo.AddActor(new Actor { Name = "Tom Hanks", BirthYear = 1956 });
        repo.AddActor(new Actor { Name = "Keanu Reeves", BirthYear = 1964 });
        repo.AddActor(new Actor { Name = "Carrie-Anne Moss", BirthYear = 1967 });
        repo.AddActor(new Actor { Name = "Laurence Fishburne", BirthYear = 1961 });
    }

    [TestMethod]
    public void GetTest()
    {
        IEnumerable<Actor> actors = repo!.GetActors();
        Assert.AreEqual(4, actors.Count());
        Assert.AreEqual("Tom Hanks", actors.ElementAt(0).Name);

        IEnumerable<Actor> sortedMovies = repo.GetActors(orderBy: "name");
        Assert.AreEqual("Carrie-Anne Moss", sortedMovies.ElementAt(0).Name);

        IEnumerable<Actor> sortedMovies2 = repo.GetActors(orderBy: "birthyear");
        Assert.AreEqual("Tom Hanks", sortedMovies2.ElementAt(0).Name);
    }

    [TestMethod]
    public void GetById()
    {
        Assert.IsNotNull(repo!.GetActorById(1));
        Assert.AreEqual("Keanu Reeves", repo.GetActorById(2)!.Name);
        Assert.AreEqual(4, repo.GetActors().Count());

        Assert.ThrowsException<ArgumentException>(() => repo.AddActor(new Actor()));
    }

    [TestMethod]
    public void AddTest()
    {
        Actor a = new() { BirthYear = 1970, Name = "Test" };
        repo!.AddActor(a);
        Assert.AreEqual(5, repo.GetActors().Count());

        Assert.ThrowsException<ArgumentException>(() => repo.AddActor(new Actor()));
    }

    [TestMethod]
    public void DeleteTest()
    {
        Assert.IsNull(repo!.DeleteActor(100));
        Assert.AreEqual(1, repo!.DeleteActor(1)?.Id);
        Assert.AreEqual(3, repo.GetActors().Count());
    }

    [TestMethod]
    public void UpdateTest()
    {
        Actor a = new() { BirthYear = 1970, Name = "Bo" };
        Assert.ThrowsException<ArgumentException>(() => repo!.UpdateActor(a));
        Actor a2 = new() { BirthYear = 1970, Name = "Eric" };
        Assert.AreEqual(5, repo!.AddActor(a2).Id);
        Assert.AreEqual(5, repo.GetActors().Count());
    }

    [TestCleanup]
    public void Cleanup()
    {
        foreach (var actor in dbContext!.Actors)
        {
            dbContext.Actors.Remove(actor);
        }
        dbContext.SaveChanges();
    }
}
