namespace SimpleRestExercise.Models;

public class StudentsRepository
{
    private List<Student> students = new List<Student>();

    public List<Student> Students => students;

    public Student Create(Student student)
    {
        if (Students.Count() == 0)
        {
            student.Id = 1;
        }
        else
        {
            student.Id = students.Count() + 1;
        }

        Students.Add(student);

        return student;
    }

    public IEnumerable<Student> Read()
    {
        IQueryable<Student> query = Students.AsQueryable();

        return query;
    }

    public IEnumerable<Student> Read(string? firstName=null, string? lastName=null, string? fullName=null, string? sortBy=null) 
    {
        IQueryable<Student> query = Students.AsQueryable();

        if (firstName != null)
        {
            query = query.Where(s => s.FirstName == firstName);
        }

        if (lastName != null)
        {
            query = query.Where(s => s.LastName == lastName);
        }

        if (fullName != null)
        {
            query = query.Where(s => s.FullName == fullName);
        }

        if (sortBy != null)
        {
            query = sortBy switch
            {
                "firstName" => query.OrderBy(s => s.FirstName),
                "lastName" => query.OrderBy(s => s.LastName),
                _ => query
            };
        }

        return query;
    }

    public Student Read(int id)
    {
        return Students[id];
    }

    public Student Update(int id, Student student)
    {
        student.Id = id;
        Students[id] = student;

        return Students[id];
    }

    public Student Delete(int id)
    {
        Student studentToRemove = Students[id];
        Students.Remove(studentToRemove);

        return studentToRemove;
    }
}
