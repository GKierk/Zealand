using SimpleRestExercise.Exceptions;
using System.Text.Json.Serialization;

namespace SimpleRestExercise.Models;

public class Student
{
    private CoursesRepository? courseRepository;

    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string FullName => $"{FirstName} {LastName}";

    private List<Course> enrolledCourses = new List<Course>();

    public List<Course> EnrolledCourses
    {
        get { return enrolledCourses; }
        set { enrolledCourses = value; }
    }

    public Student() { }

    public Student(CoursesRepository coursesRepository) 
    {
        this.courseRepository = coursesRepository;
    }

    public override string ToString()
    {
        return FullName;
    }

    public int VerifyId()
    {
        if (Id < 0)
        {
            throw new IdNotValidException("The id can't be negative.");
        }

        return Id;
    }

    public void VerifyFirstName()
    {
        if (string.IsNullOrEmpty(FirstName))
        {
            throw new FirstNameNotValidException("You must enter a first name.");
        }
    }

    public void VerifyLastName()
    {
        if (!string.IsNullOrEmpty(LastName))
        {
            throw new LastNameNotValidException("You must enter a last name.");
        }
    }

    public void VerifyEnrolledCourses()
    {
        List<Course> existingCourses = courseRepository!.Courses;

        foreach (Course course in EnrolledCourses)
        {
            if (!existingCourses.Any(c => c.Name == course.Name))
            {
                throw new CourseNotValidException("One of the selected courses is not available as one of the courses offered.");
            }
        }
    }

    public void Verify()
    {
        VerifyId();
        VerifyFirstName();
        VerifyLastName();
        VerifyEnrolledCourses();
    }

    public Course EnrollCourse(string? course, CoursesRepository avaialabeCourses)
    {
        Course courseToEnroll = avaialabeCourses.Courses.FirstOrDefault(c => c.Name == course)!;
        EnrolledCourses!.Add(courseToEnroll);
        VerifyEnrolledCourses();

        return courseToEnroll;
    }
}
