
namespace ActorRepositoryLib;

public class ActorsRepository : IActorsRespository
{
    private int nextId = 0;
    private List<Actor> actors = new List<Actor>();

    public IEnumerable<Actor> Get(int birthYearYearBefore=2024, int birthYearAfter=1820, string? name=null, string sortOrder = null!)
    {
        if (birthYearYearBefore < birthYearAfter)
        {
            throw new ArgumentException("birthYearYearBefore must be greater than birthYearAfter");
        }

        if (string.IsNullOrEmpty(name))
        {
            return actors.Where(a => a.BirthYear <= birthYearYearBefore && a.BirthYear >= birthYearAfter);
        }

        if (string.IsNullOrEmpty(sortOrder))
        {
            return actors.Where(a => a.BirthYear <= birthYearYearBefore && a.BirthYear >= birthYearAfter && a.Name != null && a.Name.Contains(name));
        }

        return actors;
    }

    public Actor GetById(int id) => actors[id];

    public Actor AddActor(Actor actor)
    {
        if (actor!= null)
        {
            actor.Id = ++nextId;
        }
        else
        {
            throw new ArgumentNullException("Actor cannot be null");
        }

        actors.Add(actor);
        return actor;
    }

    public Actor Delete(int id)
    {
        if (id < 0 || id >= actors.Count)
        {
            throw new ArgumentOutOfRangeException("Id must be a valid index");
        }

        Actor actor = actors[--id];
        actors.RemoveAt(id);
        return actor;
    }

    public Actor Update(int id, Actor actor)
    {
        if (id < 0)
        {
            throw new ArgumentOutOfRangeException("Id must be a valid index");
        }

        if (actor == null)
        {
            throw new ArgumentNullException("Actor cannot be null");
        }

        actors[id] = actor;
        return actor;
    }
}
