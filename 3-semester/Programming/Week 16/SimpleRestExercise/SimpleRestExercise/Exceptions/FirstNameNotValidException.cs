namespace SimpleRestExercise.Exceptions;

public class FirstNameNotValidException: Exception
{
    public FirstNameNotValidException() { }

    public FirstNameNotValidException(string message) : base(message) { }

    public FirstNameNotValidException(string message, Exception innerException) : base(message, innerException) { }
}
