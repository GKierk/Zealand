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

            if (actors.Any())
            {
                return Ok(actors);
            }

            return NotFound("No Actors found");
        }

        // GET api/<ActorsController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
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
