namespace SimpleRestExercise.Models;

public class CoursesRepository
{
    private static CoursesRepository? instance = null;
    private static readonly object padlock = new object();

    public static CoursesRepository Instance
    {
        get
        {
            lock (padlock)
            {
                if (instance == null)
                {
                    instance = new CoursesRepository();
                }

                return instance;
            }
        }
    }

    List<Course> existingCourses = new List<Course>()
    {
        new Course() { Id = 1, Name = "Programming" },
        new Course() { Id = 2, Name = "Technology" },
        new Course() { Id = 3, Name = "System Development" }
    };

    public List<Course> Courses => existingCourses;

    public IEnumerable<Course> Read()
    {
        IQueryable<Course> query = Courses.AsQueryable();

        return query;
    }

    public IEnumerable<Course> Read(string? name=null)
    {
        IQueryable<Course> query = Courses.AsQueryable();

        if (name != null)
        {
            query = query.Where(c => c.Name == name);
        }

        return query;
    }

    public Course Read(int id)
    {
        return Courses[id];
    }
}
