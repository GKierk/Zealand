namespace ActorRepositoryLib;

public class ActorsRepository : IActorsRepository
{
    private readonly ActorsDbContext context;

    public ActorsRepository(ActorsDbContext context)
    {
        this.context = context;
    }

    public Actor AddActor(Actor actor)
    {
        actor.Validate();
        int id = context.Actors.Count()!;

        if (id == 0)
        {

            actor.Id = 1;
            context.Actors.Add(actor);
            return actor;
        }

        actor.Id = ++id;
        context.Actors.Add(actor);
        context.SaveChanges();
        return actor;
    }

    public Actor DeleteActor(int id)
    {
        Actor? actor = GetActorById(id);

        if (actor == null)
        {
            return null!;
        }

        context?.Actors.Remove(actor);
        context?.SaveChanges();
        return actor;
    }

    public Actor? GetActorById(int id)
    {
        return context?.Actors.FirstOrDefault(a => a.Id == id);
    }

    public IEnumerable<Actor> GetActors(int? birthYear = null, string? name = null, string? orderBy = null)
    {
        IQueryable<Actor>? actors = context?.Actors.AsQueryable();

        if (actors?.Count() == 0 || actors?.Count() == null)
        {
            return null!;
        }

        if (birthYear != null)
        {
            actors = actors.Where(a => a.BirthYear == birthYear);
        }

        if (name != null)
        {
            actors = actors.Where(a => a.Name == name);
        }

        if (orderBy != null)
        {
            actors = orderBy switch
            {
                "name" => actors.OrderBy(a => a.Name),
                "birthYear" => actors.OrderBy(a => a.BirthYear),
                _ => actors
            };
        }

        return actors;
    }

    public Actor UpdateActor(Actor actor)
    {
        actor.Validate();
        Actor? actorToUpdate = GetActorById(actor.Id);

        if (actorToUpdate == null)
        {
            return null!;
        }

        actorToUpdate.Name = actor.Name;
        actorToUpdate.BirthYear = actor.BirthYear;
        context?.SaveChanges();
        return actorToUpdate;
    }
}
