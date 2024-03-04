namespace Drinks.Repository;

/// <summary>
/// Interface for the Beers Repository.
/// </summary>
public interface IBeersRepository
{
    /// <summary>
    /// Gets a list of beers based on the specified criteria.
    /// </summary>
    /// <param name="minAbv">The minimum alcohol by volume (ABV) of the beers to retrieve. Default is 0.</param>
    /// <param name="maxAbv">The maximum alcohol by volume (ABV) of the beers to retrieve. Default is 67.</param>
    /// <param name="name">The name of the beers to retrieve. Default is an empty string.</param>
    /// <param name="sortOrder">The sort order of the beers. Default is null.</param>
    /// <returns>A collection of beers that match the specified criteria.</returns>
    public IEnumerable<Beer>? Get(double minAbv = 0, double maxAbv = 67, string name = "", string? sortOrder = null);

    /// <summary>
    /// Gets a beer by its ID.
    /// </summary>
    /// <param name="Id">The ID of the beer.</param>
    /// <returns>The beer with the specified ID.</returns>
    public Beer? GetByID(int Id);

    /// <summary>
    /// Adds a new beer.
    /// </summary>
    /// <param name="beer">The beer to add.</param>
    /// <returns>The added beer.</returns>
    public Beer? Add(Beer beer);

    /// <summary>
    /// Deletes a beer by its ID.
    /// </summary>
    /// <param name="Id">The ID of the beer to delete.</param>
    /// <returns>The deleted beer.</returns>
    public Beer? Delete(int Id);

    /// <summary>
    /// Updates a beer.
    /// </summary>
    /// <param name="beer">The beer to update.</param>
    /// <returns>The updated beer.</returns>
    public Beer? Update(int id, Beer beer);
}
