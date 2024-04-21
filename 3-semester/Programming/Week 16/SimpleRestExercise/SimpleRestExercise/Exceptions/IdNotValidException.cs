namespace SimpleRestExercise.Exceptions;

public class IdNotValidException: Exception
{
    public IdNotValidException() { }

    public IdNotValidException(string message) : base(message) { }

    public IdNotValidException(string message,  Exception innerException) : base(message, innerException) { }
}
