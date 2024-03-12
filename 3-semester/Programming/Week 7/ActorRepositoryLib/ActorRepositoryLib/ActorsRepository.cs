
namespace ActorRepositoryLib;

public class ActorsRepository : IActorsRespository
{
    private int nextId = 0;
    private List<Actor> actors = new List<Actor>();

    public IEnumerable<Actor> Get(int? birthYear = null, string? name = null, string? orderBy = null)
    { 
        IQueryable<Actor> query = actors.AsQueryable();

        if (birthYear != null)
        {
            query = query.Where(a => a.BirthYear == birthYear);
        }

        if (name != null)
        {
            query = query.Where(a => a.Name == name);
        }

        if (orderBy != null)
        {
            query = orderBy switch
            {
                "name" => query.OrderBy(a => a.Name),
                "birthYear" => query.OrderBy(a => a.BirthYear),
                _ => query
            };
        }

        return query;
    }

    public Actor GetById(int id) => actors[id];

    public Actor AddActor(Actor actor)
    {
        actor.Id = nextId++;
        actors.Add(actor);
        return actor;
    }

    public Actor Delete(int id)
    {
        Actor actor = actors?.Find(a => a.Id == id)!;
        actors?.Remove(actor);
        return actor!;
    }

    public Actor Update(int id, Actor actor)
    {
        actors[id] = actor;
        return actor;
    }
}
