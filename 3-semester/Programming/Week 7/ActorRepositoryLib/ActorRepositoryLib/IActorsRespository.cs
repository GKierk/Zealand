namespace ActorRepositoryLib;

public interface IActorsRespository
{
    public IEnumerable<Actor> Get(int birthYearYearBefore = 2024, int birthYearAfter = 1820, string? name=null);
    public Actor AddActor(Actor actor);
    public Actor Delete(int id);
    public Actor Update(int id, Actor actor);
}
