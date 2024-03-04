using Drinks;
using System.Text;

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
    /// Retrieves a list of beers based on the specified criteria.
    /// </summary>
    /// <param name="minAbv">The minimum alcohol by volume (ABV) of the beers to retrieve. Default is 0.</param>
    /// <param name="maxAbv">The maximum alcohol by volume (ABV) of the beers to retrieve. Default is 67.</param>
    /// <param name="name">The name of the beers to retrieve. Default is an empty string.</param>
    /// <param name="sortOrder">The sort order of the retrieved beers. Default is null.</param>
    /// <returns>A collection of beers that match the specified criteria.</returns>
    public IEnumerable<Beer>? Get(double minAbv = 0, double maxAbv = 67, string name = "", string? sortOrder = null)
    {
        IEnumerable<Beer> result = new List<Beer>(beers);

        if (minAbv > 0)
        {
            result = result.Where(b => b.Abv >= minAbv);
        }

        if (maxAbv < 67)
        {
            result = result.Where(b => b.Abv <= maxAbv);
        }

        if (name != "")
        {
            result = result.Where(b => b.Name?.Contains(name) == true);
        }

        if (sortOrder != null)
        {
            result = sortOrder switch
            {
                "name_desc" => result.OrderByDescending(b => b.Name),
                "abv" => result.OrderBy(b => b.Abv),
                "abv_desc" => result.OrderByDescending(b => b.Abv),
                _ => result.OrderBy(b => b.Name),
            };
        }

        return result;
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
