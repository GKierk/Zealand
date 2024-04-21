namespace SimpleRestExercise.Exceptions;

public class CourseNotValidException: Exception
{
    public CourseNotValidException() { }

    public CourseNotValidException(string message) : base(message) { }

    public CourseNotValidException(string message, Exception innerException) : base(message, innerException) { }
}
