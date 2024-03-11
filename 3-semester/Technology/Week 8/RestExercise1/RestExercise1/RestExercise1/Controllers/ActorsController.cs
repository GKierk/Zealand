using Microsoft.AspNetCore.Mvc;
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
        [HttpGet]
        public IEnumerable<Actor> Get()
        {
            return repository?.Get()!;
        }

        // GET api/<ActorsController>/5
        [HttpGet("{id}")]
        public Actor Get(int id)
        {
            return repository?.GetById(id)!;
        }

        // POST api/<ActorsController>
        [HttpPost]
        public Actor Post([FromBody] Actor value)
        {
            return repository?.AddActor(value)!;
        }

        // PUT api/<ActorsController>/5
        [HttpPut("{id}")]
        public Actor Put(int id, [FromBody] Actor value)
        {
            return repository?.Update(id, value)!;
        }

        // DELETE api/<ActorsController>/5
        [HttpDelete("{id}")]
        public Actor Delete(int id)
        {
            return repository?.Delete(id)!;
        }
    }
}
