namespace Education
{
    public interface IStudent : IPerson
    {
        int Semester { get; set; }

        bool Equals(object? obj);
        int GetHashCode();
        string ToString();
        bool ValidateName();
        bool ValidateSemester();
    }
}