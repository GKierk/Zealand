using SimpleRestExercise.Utillities;

namespace SimpleRestExercise.Models;

public class CoursesRepository
{
    private static CoursesRepository? instance = null;
    private static readonly object padlock = new object();
    private static readonly string file = "course_data.json";

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

    List<Course> existingCourses = new List<Course>();

    public List<Course> Courses => existingCourses;

    public CoursesRepository()
    {
        LoadCoursesAsync().Wait();
    }

    private async Task LoadCoursesAsync()
    {
        List<Course>? loadedCourses = await FileReader<Course>.Instance!.Load(file);

        if (loadedCourses != null)
        {
            existingCourses = loadedCourses;
        }
    }

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
