namespace Beer;

/// <summary>
/// Represents a Beer with properties for Id, Name, and Abv.
/// </summary>
public class Beer : IBeer
{
    private int? id;
    private string? name;
    private double? abv;

    /// <summary>
    /// Gets or sets the Id of the Beer.
    /// <value>Id must be greater than 0</value>
    /// </summary>
    public int? Id
    {
        get { return id; }
        set
        {
            if (ValidateId(value))
            {
                id = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the Name of the Beer.
    /// <value>Name must be at least 3 characters long</value>
    /// </summary>
    public string? Name
    {
        get { return name; }
        set
        {
            if (ValidateName(value))
            {
                name = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the Abv of the Beer.
    /// <value>Abv must be between 0 and 67</value></value>
    /// </summary>
    public double? Abv
    {
        get { return abv; }
        set
        {
            if (ValidateAbv(value))
            {
                abv = value;
            }
        }
    }

    /// <summary>
    /// Returns a string that represents the current Beer.
    /// </summary>
    public override string ToString()
    {
        return $"Id: {id}, Name: {name}, Abv: {abv}";
    }

    /// <summary>
    /// Validates the Id of the Beer.
    /// <paramref name="Id"/> must be greater than 0</paramref>
    /// <returns>true if the ID is valid; otherwise, throws an ArgumentOutOfRangeException.</returns>
    /// </summary>
    public bool ValidateId(int? Id)
    {
        if (Id != null && 0 < Id)
        {
            return true;
        }
        else
        {
            throw new ArgumentOutOfRangeException("Id must be greater than 0");
        }
    }

    /// <summary>
    /// Validates the Name of the Beer.
    /// <paramref name="Name"/> must be at least 3 characters long</paramref>
    /// <returns>true if the ID is valid; otherwise, throws an ArgumenException.</returns>
    /// </summary>
    public bool ValidateName(string? Name)
    {
        if (Name != null && 3 <= Name.Length)
        {
            return true;
        }
        else
        {
            throw new ArgumentException("Name must be at least 3 characters long");
        }
    }

    /// <summary>
    /// Validates the Abv of the Beer.
    /// <paramref name="Abv"/> must be between 0 and 67</paramref>
    /// <returns>true if the ID is valid; otherwise, throws an ArgumentOutOfRangeException.</returns>
    /// </summary>
    public bool ValidateAbv(double? Abv)
    {
        if (Abv != null && 0 <= Abv && Abv <= 67)
        {
            return true;
        }
        else
        {
            throw new ArgumentOutOfRangeException("Abv must be between 0 and 67");
        }
    }
}
