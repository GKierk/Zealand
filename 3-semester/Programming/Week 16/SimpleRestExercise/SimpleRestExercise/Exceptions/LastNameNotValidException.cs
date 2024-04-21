namespace SimpleRestExercise.Exceptions;

public class LastNameNotValidException: Exception
{
    public LastNameNotValidException() { }

    public LastNameNotValidException(string message) : base(message) { }

    public LastNameNotValidException(string message, Exception innerException) : base(message, innerException) { }
}
