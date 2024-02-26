using Drinks.Repository;

namespace Drinks.Tests
{
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
            Assert.AreEqual(2, beersRepository.Get().Count());
            Assert.AreEqual(returnValue1, beersRepository.Get().ElementAt(0));
            Assert.AreEqual(returnValue2, beersRepository.Get().ElementAt(1));
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
            Assert.AreEqual(2, beersRepository.Get().Count());
            Beer? deletedBeer = beersRepository.Delete(1);
            Assert.AreEqual(deletedBeer, deletedBeer);
            Assert.AreEqual(1, beersRepository.Get().Count());
        }

        [TestMethod]
        public void GetTest()
        {
            BeersRepository beersRepository = new BeersRepository();
            List<Beer> expectedValues = new List<Beer>();
            var beer1 = new Beer { Id = 1, Name = "Test Beer 1", Abv = 5.0 };
            var beer2 = new Beer { Id = 2, Name = "Test Beer 2", Abv = 6.0 };

            beersRepository.Add(beer1);
            beersRepository.Add(beer2);
            expectedValues.Add(beer1);
            expectedValues.Add(beer2);

            Assert.IsNotNull(beersRepository.Get());
            Assert.IsNotNull(expectedValues.ToList());
            Assert.AreEqual(expectedValues.Count(), beersRepository.Get().Count());
            CollectionAssert.AreEqual(expectedValues.ToList(), beersRepository.Get());
        }

        [TestMethod]
        public void GetMinABVMaxABVTest()
        {
            BeersRepository beersRepository = new BeersRepository();
            List<Beer> expectedValues = new List<Beer>();
            var beer1 = new Beer { Id = 1, Name = "Test Beer 1", Abv = 5.0 };
            var beer2 = new Beer { Id = 2, Name = "Test Beer 2", Abv = 6.0 };
            var beer3 = new Beer { Id = 3, Name = "Test Beer 3", Abv = 7.0 };
            var beer4 = new Beer { Id = 4, Name = "Test Beer 4", Abv = 8.0 };

            beersRepository.Add(beer1);
            beersRepository.Add(beer2);
            beersRepository.Add(beer3);
            beersRepository.Add(beer4);
            expectedValues.Add(beer2);
            expectedValues.Add(beer3);

            Assert.IsNotNull(beersRepository.Get(6.0, 7.0));
            Assert.IsNotNull(expectedValues.ToList());
            Assert.AreEqual(expectedValues.Count(), beersRepository.Get(6.0, 7.0).Count());
            CollectionAssert.AreEqual(expectedValues.ToList(), beersRepository.Get(6.0, 7.0));
        }

        [TestMethod]
        public void GetNameMinABVMaxABVTest()
        {
            BeersRepository beersRepository = new BeersRepository();
            List<Beer> expectedValues = new List<Beer>();
            var beer1 = new Beer { Id = 1, Name = "Test Beer 1", Abv = 5.0 };
            var beer2 = new Beer { Id = 2, Name = "Test Beer 2", Abv = 6.0 };
            var beer3 = new Beer { Id = 3, Name = "Test Beer 3", Abv = 7.0 };
            var beer4 = new Beer { Id = 4, Name = "Test Beer 4", Abv = 8.0 };

            beersRepository.Add(beer1);
            beersRepository.Add(beer2);
            beersRepository.Add(beer3);
            beersRepository.Add(beer4);
            expectedValues.Add(beer2);
            expectedValues.Add(beer3);

            Assert.IsNotNull(beersRepository.Get("Test Beer", 6.0, 7.0));
            Assert.IsNotNull(expectedValues.ToList());
            Assert.AreEqual(expectedValues.Count(), beersRepository.Get("Test Beer", 6.0, 7.0).Count());
            CollectionAssert.AreEqual(expectedValues.ToList(), beersRepository.Get("Test Beer", 6.0, 7.0));
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
}
