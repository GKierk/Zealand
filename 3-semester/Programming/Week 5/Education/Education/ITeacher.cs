
namespace Education
{
    public interface ITeacher : IPerson
    {
        List<string> Classes { get; set; }
        int Salary { get; set; }

        bool Equals(object? obj);
        int GetHashCode();
        string ToString();
        bool ValidateClasses();
        bool ValidateName();
        bool ValidateSalary();
    }
}