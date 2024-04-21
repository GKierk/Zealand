using SimpleRestExercise.Utilities;

namespace SimpleRestExercise.Models;

public class StudentsRepository
{
    private static readonly string file = "students_data.json";
    private List<Student> students = new List<Student>();
    private FileReader<Student> fileReader = new FileReader<Student>();

    public List<Student> Students
    {
        get { return students; }
        set { students = value; }
    }

    public event EventHandler? StudentsLoaded;

    public async Task InitializeAsync()
    {
        await LoadStudentsAsync();
        OnDataLoaded();
    }

    private async Task LoadStudentsAsync()
    {
        List<Student>? loadedStudents = await fileReader.LoadAsync(file);

        if (loadedStudents != null)
        {
            Students = loadedStudents;
        }
    }

    private void OnDataLoaded()
    {
        StudentsLoaded?.Invoke(this, EventArgs.Empty);
    }

    public async Task<Student> CreateAsync(Student student)
    {
        if (Students.Count == 0)
        {
            student.Id = 1;
        }
        else
        {
            student.Id = Students.Max(s => s.Id) + 1;
        }

        Students.Add(student);
        await fileReader.SaveAsync(file, Students);

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
