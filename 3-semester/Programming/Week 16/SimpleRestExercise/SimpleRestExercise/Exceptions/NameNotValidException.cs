namespace SimpleRestExercise.Exceptions;

public class NameNotValidException : Exception
{
    public NameNotValidException() { }

    public NameNotValidException(string message) : base(message) { }

    public NameNotValidException(string message, Exception innerException) : base(message, innerException) { }
}