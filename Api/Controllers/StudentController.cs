using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.DAL.Repositories;
using Api.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IAsyncRepository<Student> _repository;

        public StudentController(IAsyncRepository<Student> repository)
        {
            _repository = repository;
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> Get()
        {
            return Ok(await _repository.GetAllAsync());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> Get(Guid id)
        {
            return Ok(await _repository.GetAsync(id));
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<Student>> Post([FromBody]Student student)
        {
            var dbStudent = await _repository.AddAsync(student);
            return Ok(dbStudent);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Student>> Put(Guid id, [FromBody] Student student)
        {
            var dbStudent = await _repository.UpdateAsync(student);
            return Ok(dbStudent);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var dbStudent = await _repository.GetAsync(id);
            await _repository.DeleteAsync(dbStudent);
            return Ok();
        }
    }
}
