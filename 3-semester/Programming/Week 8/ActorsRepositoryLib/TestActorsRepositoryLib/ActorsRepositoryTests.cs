using Microsoft.EntityFrameworkCore;

namespace ActorRepositoryLib.Tests;

[TestClass]
public class ActorsRepository
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
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ActorsDb;Trusted_Connection=True;MultipleActiveResultSets=true");
            dbContext = new ActorsDbContext(optionsBuilder.Options);
        }
    }

    [TestInitialize]
    public void Init()
    {
        if (useDatabase)
        {
            repo = new ActorsRepository(dbContext);
            dbContext?.Database.ExecuteSqlRaw("Truncate Table dbo.Actors");
        }

        repo.AddActor(new Actor { Name = "Tom Hanks", BirthYear = 1956 });
        repo.AddActor(new Actor { Name = "Keanu Reeves", BirthYear = 1964 });
        repo.AddActor(new Actor { Name = "Carrie-Anne Moss", BirthYear = 1967 });
        repo.AddActor(new Actor { Name = "Laurence Fishburne", BirthYear = 1961 });
    }

}
