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
    public class StudentsController : ControllerBase
    {
        private readonly IAsyncRepository<Student> _repository;
        private readonly IAsyncRepository<StudentAddress> _addressRepository;
        private readonly IUnitOfWork _uow;

        public StudentsController(
            IAsyncRepository<Student> repository,
            IAsyncRepository<StudentAddress> addressRepository,
            IUnitOfWork uow)
        {
            _repository = repository;
            _addressRepository = addressRepository;
            _uow = uow;
        }

        // Unit of work
        [HttpGet]
        [Route("create")]
        public async Task<ActionResult> Create()
        {
            var student = new Student() {
                Email = "test@email.com"
            };

            await _repository.AddAsync(student);

            var address = new StudentAddress()
            {
                StudentId = student.Id
            };

            await _addressRepository.AddAsync(address);

            await _uow.CommitAsync();

            return Ok();
        }
    }
}
