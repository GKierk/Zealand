namespace Education;

public abstract class Person : IPerson
{
    private int id;
    private string? name;
    private Genders? gender;

    public enum Genders
    {
        Male,
        Female
    }

    public int ID
    {
        get => id;
        set => id = value;
    }

    public string? Name
    {
        get => name;
        set => name = value;
    }

    public Genders? Gender
    {
        get => gender;
        set => gender = value;
    }

    public override string ToString()
    {
        return $"ID: {ID}, Name: {Name}, Gender: {this.gender}";
    }
    public bool ValidateID(int id)
    {
        return ID > 0;
    }

    public bool ValidateName(string? name)
    {
        return !string.IsNullOrEmpty(Name);
    }

    public bool ValidateGender(Genders? gender)
    {
        if (gender == null || this.gender != Genders.Male || this.gender != Genders.Female)
        {
            throw new Exception("Gender has not been set to male or female.");
        }

        return true;
    }

    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        Person p = (Person)obj;
        return ID == p.ID && Name == p.Name;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(ID, Name);
    }
}
