﻿using SimpleRestExercise.Utilities;

namespace SimpleRestExercise.Models;

public class CoursesRepository
{
    private static CoursesRepository? instance = null;
    private static readonly object padlock = new object();
    private static readonly string file = "course_data.json";
    private List<Course> courses = new List<Course>();

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


    public List<Course> Courses
    {
        get { return courses; }
        set { courses = value; }
    }

    public event EventHandler? CoursesLoaded;

    public async Task InitializeAsync()
    {
        await LoadCoursesAsync();
        OnDataLoaded();
    }

    private async Task LoadCoursesAsync()
    {
        List<Course>? loadedCourses = await FileReader<Course>.Instance!.Load(file);

        if (loadedCourses != null)
        {
            Courses = loadedCourses;
        }
    }

    private void OnDataLoaded()
    {
        CoursesLoaded!.Invoke(this, EventArgs.Empty);
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
