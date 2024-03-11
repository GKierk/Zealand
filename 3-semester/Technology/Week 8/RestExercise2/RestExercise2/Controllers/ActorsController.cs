using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ActorRepositoryLib;

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
        }

        // GET: api/<ActorsController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public IActionResult Get()
        {
            List<Actor> actors = repository?.Get().ToList()!;

            if (!actors.Any())
            {
                return NotFound("No Actors found");
            }

            return Ok(actors);
        }

        // GET api/<ActorsController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Actor actor = repository?.GetById(id)!;
            if (actor == null)
            {
                return NotFound("No such actor, id: " + id);
            }

            return Ok(actor);
        }

        // POST api/<ActorsController>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult Post([FromBody] Actor value)
        {
            Actor actor = repository?.AddActor(value)!;

            if (actor == null)
            {
                return BadRequest();
            }

            return Ok(actor);
        }

        // PUT api/<ActorsController>/5
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Actor value)
        {
            Actor actor = repository?.Update(id, value)!;

            if (repository!.Get().Any(a => a.Id != id) || actor == null)
            {
                return Conflict();
            }

            return Ok(actor);
        }

        // DELETE api/<ActorsController>/5
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Actor actor = repository?.Delete(id)!;

            if(repository!.Get().Any(a => a.Id != id))
            {
                return NotFound();
            }

            return Ok(actor);
        }
    }
}
