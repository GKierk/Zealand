using Drinks.Repository;

namespace Drinks.Tests;

[TestClass]
public class BeersRepositoryTests
{
    [TestMethod]
    public void AddTest()
    {
        BeersRepository beersRepository = new BeersRepository();
        var beer1 = new Beer { Id = 1, Name = "Test Beer 1", Abv = 5.0 };
        var beer2 = new Beer { Id = 2, Name = "Test Beer 2", Abv = 6.0 };

        Beer? returnValue1 = beersRepository.Add(beer1);
        Beer? returnValue2 = beersRepository.Add(beer2);

        beersRepository.Get();

        Assert.IsNotNull(beersRepository.Get());
        Assert.AreEqual(2, beersRepository.Get()?.Count());
        Assert.AreEqual(returnValue1, beersRepository.Get()?.ElementAt(0));
        Assert.AreEqual(returnValue2, beersRepository.Get()?.ElementAt(1));
    }

    [TestMethod]
    public void DeleteTest()
    {
        BeersRepository beersRepository = new BeersRepository();
        var beer1 = new Beer { Id = 1, Name = "Test Beer 1", Abv = 5.0 };
        var beer2 = new Beer { Id = 2, Name = "Test Beer 2", Abv = 6.0 };

        beersRepository.Add(beer1);
        beersRepository.Add(beer2);

        Assert.IsNotNull(beersRepository.Get());
        Assert.AreEqual(2, beersRepository.Get()?.Count());
        Beer? deletedBeer = beersRepository.Delete(1);
        Assert.AreEqual(deletedBeer, deletedBeer);
        Assert.AreEqual(1, beersRepository.Get()?.Count());
    }

    [TestMethod]
    public void GetByMinAbvTest()
    {
        var beer1 = new Beer { Id = 1, Name = "Test Beer 1", Abv = 5.0 };
        var beer2 = new Beer { Id = 2, Name = "Test Beer 2", Abv = 6.0 };
        var beer3 = new Beer { Id = 3, Name = "Test Beer 3", Abv = 7.0 };
        var beer4 = new Beer { Id = 4, Name = "Test Beer 4", Abv = 8.0 };
        var beer5 = new Beer { Id = 5, Name = "Test Beer 5", Abv = 9.0 };

        BeersRepository beersRepository = new BeersRepository();

        for (int i = 1; i <= 5; i++)
        {
            beersRepository.Add(new Beer { Id = i, Name = "Test Beer " + i, Abv = i + 4.0 });
        }

        Assert.AreEqual(5, beersRepository.Get(5.0)?.Count());
        Assert.AreEqual(4, beersRepository.Get(6.0)?.Count());
        Assert.AreEqual(3, beersRepository.Get(7.0)?.Count());
        Assert.AreEqual(2, beersRepository.Get(8.0)?.Count());
        Assert.AreEqual(1, beersRepository.Get(9.0)?.Count());
    }

    [TestMethod]
    public void GetByMaxAbvTest()
    {
        BeersRepository beersRepository = new BeersRepository();

        for (int i = 1; i <= 5; i++)
        {
            beersRepository.Add(new Beer { Id = i, Name = $"Test Beer {i}", Abv = i + 4.0 });
        }

        Assert.AreEqual(1, beersRepository.Get(5.0, 5.0)?.Count());
        Assert.AreEqual(2, beersRepository.Get(5.0, 6.0)?.Count());
        Assert.AreEqual(3, beersRepository.Get(5.0, 7.0)?.Count());
        Assert.AreEqual(4, beersRepository.Get(5.0, 8.0)?.Count());
        Assert.AreEqual(5, beersRepository.Get(5.0, 9.0)?.Count());
    }

    [TestMethod]
    public void GetByName()
    {

        BeersRepository beersRepository = new BeersRepository();

        for (int i = 1; i <= 5; i++)
        {
            beersRepository.Add(new Beer { Id = i, Name = $"Test Beer {i}", Abv = i + 4.0 });
        }

        Assert.AreEqual("Test Beer 1", beersRepository.Get(0, 67)?.FirstOrDefault(beer => beer.Name == "Test Beer 1")?.Name);
        Assert.AreEqual("Test Beer 2", beersRepository.Get(0, 67)?.FirstOrDefault(beer => beer.Name == "Test Beer 2")?.Name);
        Assert.AreEqual("Test Beer 3", beersRepository.Get(0, 67)?.FirstOrDefault(beer => beer.Name == "Test Beer 3")?.Name);
    }

    [TestMethod]
    public void GetByIdTest()
    {
        BeersRepository beersRepository = new BeersRepository();
        var beer1 = new Beer { Id = 1, Name = "Test Beer 1", Abv = 5.0 };
        var beer2 = new Beer { Id = 2, Name = "Test Beer 2", Abv = 6.0 };

        beersRepository.Add(beer1);
        beersRepository.Add(beer2);

        Assert.IsNotNull(beersRepository.GetByID(1));
        Assert.AreEqual(beer1, beersRepository.GetByID(1));
    }

    [TestMethod]
    public void UpdateTest()
    {
        BeersRepository beersRepository = new BeersRepository();
        var beer1 = new Beer { Id = 1, Name = "Test Beer 1", Abv = 5.0 };
        var beer2 = new Beer { Id = 2, Name = "Test Beer 2", Abv = 6.0 };

        beersRepository.Add(beer1);
        beersRepository.Add(beer2);

        var updatedBeer = new Beer { Id = 1, Name = "Updated Beer 1", Abv = 7.0 };
        beersRepository.Update(1, updatedBeer);

        Assert.IsNotNull(beersRepository.GetByID(1));
        Assert.AreEqual(updatedBeer.ToString(), beersRepository.GetByID(1)?.ToString());
    }
}
