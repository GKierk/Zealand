using Microsoft.AspNetCore.Mvc;
using SimpleRestExercise.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SimpleRestExercise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        // GET: api/<StudentsController>
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            foreach (var student in StudentsRepository.Instance.Read())
            {
                Console.WriteLine(student);
            }

            return StudentsRepository.Instance.Read();
        }

        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        public Student Get(int id)
        {
            return StudentsRepository.Instance.Read(id);
        }

        // POST api/<StudentsController>
        [HttpPost]
        public async Task Post([FromBody] Student student)
        {
            await StudentsRepository.Instance.CreateAsync(student);
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
