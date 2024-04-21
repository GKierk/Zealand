using SimpleRestExercise.Exceptions;

namespace SimpleRestExercise.Models;

public class Student
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string FullName => $"{FirstName} {LastName}";

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

    public void Verify()
    {
        VerifyId();
        VerifyFirstName();
        VerifyLastName();
    }
}
