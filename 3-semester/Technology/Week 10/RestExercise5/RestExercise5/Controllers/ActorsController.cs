using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ActorRepositoryLib;
using Microsoft.AspNetCore.Cors;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestExercise1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly ActorsRepository? repository;

        public ActorsController(ActorsRepository repository)
        {
            this.repository = repository;
            GenerateActors();
        }

        private void GenerateActors()
        {
            List<Actor> actors = new List<Actor>
            {
                new Actor { Name = "Tom Hanks", BirthYear = 1956 },
                new Actor { Name = "Meryl Streep", BirthYear = 1949 },
                new Actor { Name = "Leonardo DiCaprio", BirthYear = 1974 },
                new Actor { Name = "Emma Stone", BirthYear = 1988 },
                new Actor { Name = "Denzel Washington", BirthYear = 1954 },
                new Actor { Name = "Scarlett Johansson", BirthYear = 1984 },
                new Actor { Name = "Brad Pitt", BirthYear = 1963 },
                new Actor { Name = "Jennifer Lawrence", BirthYear = 1990 },
                new Actor { Name = "Johnny Depp", BirthYear = 1963 },
                new Actor { Name = "Angelina Jolie", BirthYear = 1975 },
                new Actor { Name = "Robert Downey Jr.", BirthYear = 1965 },
                new Actor { Name = "Charlize Theron", BirthYear = 1975 },
                new Actor { Name = "Will Smith", BirthYear = 1968 },
                new Actor { Name = "Natalie Portman", BirthYear = 1981 },
                new Actor { Name = "Matt Damon", BirthYear = 1970 }
            };

            foreach (var actor in actors)
            {
                repository?.AddActor(actor);
            }
        }

        // GET: api/<ActorsController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        [EnableCors("AllowAll")]
        public IActionResult Get([FromQuery] int birthYear, [FromQuery] string name, [FromQuery] string orderBy)
        {
            List<Actor> actors = repository?.Get().ToList()!;

            if (actors.Any())
            {
                return Ok(repository!.Get(birthYear, name, orderBy));
            }

            return NotFound("No Actors found");
        }

        // GET api/<ActorsController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        [EnableCors("AllowAll")]
        public IActionResult GetId(int id)
        {
            Actor actor = repository?.GetById(id)!;
            if (actor.Validate())
            {
                return Ok(actor);
            }

            return NotFound("No such actor, id: " + id);
        }

        // POST api/<ActorsController>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        [EnableCors("AllowAll")]
        public ActionResult Post([FromBody] Actor value)
        {
            if(value.Validate())
            {
                Actor actor = value;
                repository?.AddActor(actor);
                return Ok(value);
            }

            return BadRequest();
        }

        // PUT api/<ActorsController>/5
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [HttpPut("{id}")]
        [EnableCors("AllowAll")]
        public ActionResult Put(int id, [FromBody] Actor value)
        {
            if(value.Validate() && repository!.Get().Any(a => a.Id == id))
            {
                Actor actor = value;
                repository?.Update(id, actor);
                return Ok(value);
            }

            return Conflict();
        }

        // DELETE api/<ActorsController>/5
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        [EnableCors("AllowAll")]
        public ActionResult Delete(int id)
        {
            Actor actor = repository?.Delete(id)!;

            if(actor.Validate() && repository!.Get().Any(a => a.Id == id))
            {
                return Ok(actor);
            }

            return NotFound();
        }
    }
}
