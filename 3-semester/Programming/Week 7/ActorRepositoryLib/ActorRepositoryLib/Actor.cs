namespace ActorRepositoryLib;

public class Actor : IActor
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int BirthYear { get; set; }

    public override string ToString()
    {   
        return $"Id: {Id}, Name: {Name}, BirthYear: {BirthYear}";
    }

    public bool ValidateId()
    {
        if (Id > 0)
        {
            return true;
        }

        throw new ArgumentException("Id must be greater than 0");
    }

    public bool ValidateName()
    {
        if (!string.IsNullOrEmpty(Name) && Name.Length >= 3)
        {
            return true;
        }

        throw new ArgumentException("Name can't be empty and must be at least 3 charaters long.");
    }

    public bool ValidateBirthYear()
    {
        if (BirthYear >= 1820)
        {
            return true;
        }

        throw new ArgumentException("Birth year must be greater than 1820");
    }

    public bool Validate()
    {
        return ValidateId() && ValidateName() && ValidateBirthYear();
    }
}