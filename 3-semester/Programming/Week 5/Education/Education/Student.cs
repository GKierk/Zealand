namespace Education;

public class Student : Person, IStudent
{
    private int semester;

    public int Semester
    {
        get => semester;
        set => semester = value;
    }

    public override string ToString() => base.ToString() + $", Semester: {Semester}";

    public bool ValidateName()
    {
        if (Name == null || Name.Length <= 0)
        {
            throw new ArgumentException("Name cannot be null or empty");
        }

        return true;
    }

    public bool ValidateSemester()
    {
        if (semester < 1 || semester > 8)
        {
            throw new ArgumentException("Semester must be 1 to 8");
        }

        return true;
    }

    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        Student student = (Student)obj;
        return base.Equals(obj) && Semester == student.Semester;
    }

    public override int GetHashCode() => base.GetHashCode() ^ Semester;
}
