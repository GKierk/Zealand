using SimpleRestExercise.Exceptions;

namespace SimpleRestExercise.Models;

public class Course
{
    public int Id { get; set; }
    public string? Name { get; set; }

    public void VerifyId()
    {
        if (Id < 0)
        {
            throw new IdNotValidException("The id can't be negative.");
        }
    }

    public void VerifyName()
    {
        if (!string.IsNullOrEmpty(Name))
        {
            throw new NameNotValidException("The course name can't be empty");
        }
    }
}   