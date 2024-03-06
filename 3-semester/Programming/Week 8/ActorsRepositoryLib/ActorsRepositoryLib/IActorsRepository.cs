namespace ActorRepositoryLib;

public interface IActorsRepository
{
    IEnumerable<Actor> GetActors(int? birthYear = null, string? name = null, string? orderBy = null);
    Actor? GetActorById(int id);
    Actor AddActor(Actor actor);
    Actor UpdateActor(Actor actor);
    Actor DeleteActor(int id);
}
