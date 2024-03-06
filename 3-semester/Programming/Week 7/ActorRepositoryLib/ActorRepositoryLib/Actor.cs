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
        if (Id < 1)
        {
            throw new ArgumentException("Id must be greater than 0");
        }

        return true;
    }

    public bool ValidateName()
    {
        if (string.IsNullOrEmpty(Name))
        {
            throw new ArgumentException("Name cannot be null or empty");
        }

        if (Name.Length < 3)
        {
            throw new ArgumentException("Name must be at least 3 characters long");
        }

        return true;
    }

    public bool ValidateBirthYear()
    {
        if (BirthYear <= 1820)
        {
            throw new ArgumentException("Birth year must be greater than 1820");
        }

        return true;
    }
}