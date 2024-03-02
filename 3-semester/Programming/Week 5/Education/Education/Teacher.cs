namespace Education;

public class Teacher : Person, ITeacher
{
    private int id;
    private string? name;
    private int salary;
    private List<string> classes = new List<string>();

    public int Salary
    {
        get => salary;
        set => salary = value;
    }

    public List<string> Classes
    {
        get => classes;
        set => classes = value;
    }

    public override string ToString() => base.ToString() + $", Salary: {salary}";

    public bool ValidateName()
    {
        if (Name == null || Name.Length <= 0)
        {
            throw new ArgumentException("Name cannot be null or empty");
        }

        return true;
    }

    public bool ValidateSalary()
    {
        if (salary < 0)
        {
            throw new ArgumentException("Salary cannot be less than 0");
        }

        return true;
    }

    public bool ValidateClasses()
    {
        if (classes.Count <= 0)
        {
            throw new ArgumentException("Classes cannot be null or empty");
        }

        return true;
    }

    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        Teacher teacher = (Teacher)obj;
        return base.Equals(obj) && Salary == teacher.Salary && Classes == teacher.Classes;
    }

    public override int GetHashCode() => base.GetHashCode() ^ Salary ^ Classes.GetHashCode();
}
