using Drinks;

namespace BeersRepository;

/// <summary>
/// Interface for the Beers Repository.
/// </summary>
public interface IBeersRepository
{
    /// <summary>
    /// Gets all beers.
    /// </summary>
    /// <returns>A list of beers.</returns>
    public List<Beer> Get();

    /// <summary>
    /// Gets a beer by its Alcohol by Volume (Abv).
    /// </summary>
    /// <param name="Abv">The Abv of the beer.</param>
    /// <returns>The beer with the specified Abv.</returns>
    public Beer Get(double Abv);

    /// <summary>
    /// Gets a beer by its name and Alcohol by Volume (Abv).
    /// </summary>
    /// <param name="Name">The name of the beer.</param>
    /// <param name="Abv">The Abv of the beer.</param>
    /// <returns>The beer with the specified name and Abv.</returns>
    public Beer Get(string Name, double Abv);

    /// <summary>
    /// Gets a beer by its ID.
    /// </summary>
    /// <param name="Id">The ID of the beer.</param>
    /// <returns>The beer with the specified ID.</returns>
    public Beer GetByID(int? Id);

    /// <summary>
    /// Adds a new beer.
    /// </summary>
    /// <param name="beer">The beer to add.</param>
    /// <returns>The added beer.</returns>
    public Beer Add(Beer beer);

    /// <summary>
    /// Deletes a beer by its ID.
    /// </summary>
    /// <param name="Id">The ID of the beer to delete.</param>
    /// <returns>The deleted beer.</returns>
    public Beer Delete(int? Id);

    /// <summary>
    /// Updates a beer.
    /// </summary>
    /// <param name="beer">The beer to update.</param>
    /// <returns>The updated beer.</returns>
    public Beer Update(Beer beer);
}
