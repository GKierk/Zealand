namespace ActorRepositoryLib;

public interface IActorsRespository
{
    public IEnumerable<Actor> Get(int? birthYear = null, string? name = null, string? orderBy = null);
    public Actor GetById(int id);
    public Actor AddActor(Actor actor);
    public Actor Delete(int id);
    public Actor Update(int id, Actor actor);
}
