namespace Education
{
    public interface IPerson
    {
        Person.Genders? Gender { get; set; }
        int ID { get; set; }
        string? Name { get; set; }

        bool Equals(object? obj);
        int GetHashCode();
        string ToString();
        bool ValidateGender(Person.Genders? gender);
        bool ValidateID(int id);
        bool ValidateName(string? name);
    }
}