using Microsoft.AspNetCore.Mvc;
using SimpleRestExercise.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SimpleRestExercise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly StudentsRepository studentsRepository;

        public StudentsController(StudentsRepository studentsRepository) 
        {
            this.studentsRepository = studentsRepository;
        }

        // GET: api/<StudentsController>
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return studentsRepository.Read();
        }

        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        public Student Get(int id)
        {
            return studentsRepository.Read(id);
        }

        // POST api/<StudentsController>
        [HttpPost]
        public async Task Post([FromBody] Student student)
        {
            await studentsRepository.CreateAsync(student);
        }

        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
