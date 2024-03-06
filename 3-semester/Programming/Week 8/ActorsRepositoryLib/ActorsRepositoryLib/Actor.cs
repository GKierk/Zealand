namespace ActorRepositoryLib;

public class Actor
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int BirthYear { get; set; }

    public override string ToString()
    {
        return $"{Id}: {Name} ({BirthYear})";
    }

    public bool ValidateName()
    {
        if (Name == null || Name?.Length < 3)
        {
            throw new ArgumentException("Name must be at least 3 characters long.");
        }

        return true;
    }

    public bool ValidateBirthYear()
    {
        if (BirthYear < 1820)
        {
            throw new ArgumentException("Birth year must be 1820 or later.");
        }

        return true;
    }

    public bool Validate()
    {
        return ValidateName() && ValidateBirthYear();
    }
}
