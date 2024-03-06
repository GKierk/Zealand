namespace ActorRepositoryLib;

public interface IActor
{
    int BirthYear { get; set; }
    int Id { get; set; }
    string? Name { get; set; }

    public string ToString();
    public bool ValidateBirthYear();
    public bool ValidateId();
    public bool ValidateName();
}