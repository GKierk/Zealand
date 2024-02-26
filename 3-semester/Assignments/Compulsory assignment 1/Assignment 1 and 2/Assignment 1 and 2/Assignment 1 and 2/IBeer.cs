using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beer;

/// <summary>
/// Interface for Beer
/// </summary>
public interface IBeer
{
    /// <summary>
    /// Returns a string that represents the current object.
    /// </summary>
    /// <returns>A string that represents the current object.</returns>
    public string ToString();

    /// <summary>
    /// Validates the ID of the beer.
    /// </summary>
    /// <param name="Id">The ID to validate.</param>
    /// <returns>true if the ID is valid; otherwise, throw an appropriate exception.</returns>
    public bool ValidateId(int? Id);

    /// <summary>
    /// Validates the name of the beer.
    /// </summary>
    /// <param name="Name">The name to validate.</param>
    /// <returns>true if the name is valid; otherwise, throw an appropriate exception.</returns>
    public bool ValidateName(string? Name);

    /// <summary>
    /// Validates the Alcohol by Volume (ABV) of the beer.
    /// </summary>
    /// <param name="Abv">The ABV to validate.</param>
    /// <returns>true if the ABV is valid; otherwise, throw an appropriate exception.</returns>
    public bool ValidateAbv(double? Abv);
}
