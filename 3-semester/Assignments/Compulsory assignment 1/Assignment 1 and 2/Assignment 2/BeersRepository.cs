using Drinks;

namespace Drinks.Repository;

/// <summary>
/// Repository for managing beers.
/// </summary>
public class BeersRepository : IBeersRepository
{
    private List<Beer> beers = new List<Beer>();

    /// <summary>
    /// Gets the list of beers.
    /// </summary>
    public List<Beer> Beers => beers;

    /// <summary>
    /// Adds a new beer to the repository.
    /// </summary>
    /// <param name="beer">The beer to add.</param>
    /// <returns>The added beer, or null if the beer is null.</returns>
    public Beer? Add(Beer beer)
    {
        if (beer != null)
        {
            beers.Add(beer);
            return beer;
        }

        return null;
    }

    /// <summary>
    /// Deletes a beer from the repository.
    /// </summary>
    /// <param name="id">The id of the beer to delete.</param>
    /// <returns>The deleted beer, or null if the id is not valid.</returns>
    public Beer? Delete(int id)
    {
        if (0 < id && id <= beers.Count)
        {
            Beer? beerToRemove = beers.FirstOrDefault(beer => beer.Id == id);
            if (beerToRemove != null)
            {
                beers.Remove(beerToRemove);
                return beerToRemove;
            }
        }

        return null;
    }

    /// <summary>
    /// Gets all beers from the repository.
    /// </summary>
    /// <returns>A list of all beers.</returns>
    public List<Beer> Get()
    {
        return new List<Beer>(Beers).ToList();
    }

    /// <summary>
    /// Gets beers with ABV within the specified range.
    /// </summary>
    /// <param name="minAbv">The minimum ABV.</param>
    /// <param name="maxAbv">The maximum ABV.</param>
    /// <returns>A list of beers with ABV within the specified range.</returns>
    public List<Beer> Get(double minAbv, double maxAbv)
    {
        return new List<Beer>(Beers.Where(b => b.Abv >= minAbv && b.Abv <= maxAbv).ToList());
    }

    /// <summary>
    /// Gets beers with the specified name and ABV within the specified range.
    /// </summary>
    /// <param name="name">The name of the beer.</param>
    /// <param name="minAbv">The minimum ABV.</param>
    /// <param name="maxAbv">The maximum ABV.</param>
    /// <returns>A list of beers with the specified name and ABV within the specified range.</returns>
    public List<Beer> Get(string name, double minAbv, double maxAbv)
    {
        return new List<Beer>(Beers.Where(b => b.Name?.Contains(name) == true && b.Abv >= minAbv && b.Abv <= maxAbv).ToList());
    }

    /// <summary>
    /// Gets a beer by its id.
    /// </summary>
    /// <param name="Id">The id of the beer.</param>
    /// <returns>The beer with the specified id, or null if the id is not valid.</returns>
    public Beer? GetByID(int id)
    {
        return (id > 0 && id < beers.Count) ? beers.Find(b => b.Id == id) : null;
    }

    /// <summary>
    /// Updates a beer in the repository.
    /// </summary>
    /// <param name="id">The id of the beer to update.</param>
    /// <param name="beer">The new beer data.</param>
    /// <returns>The updated beer, or null if the id is not valid or the beer is null.</returns>
    public Beer? Update(int id, Beer beer)
    {
        if (0 < id && id < Beers.Count && beer != null)
        {
            Beer? beerToUpdate = Beers.Find(b => b.Id == id);
            if (beerToUpdate != null)
            {
                beerToUpdate.Id = beer.Id;
                beerToUpdate.Name = beer.Name;
                beerToUpdate.Abv = beer.Abv;

                return beerToUpdate;
            }
        }

        return null;
    }
}
