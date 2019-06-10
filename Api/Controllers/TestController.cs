using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.DAL;
using Api.DAL.Repositories;
using Api.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly IConfiguration _configuration;

        public TestController(ApplicationDbContext db, IConfiguration configuration)
        {
            _db = db;
            _configuration = configuration;
        }

        // Lazy Loading
        [HttpGet]
        [Route("lazy")]
        public ActionResult Lazy()
        {
            //var students = _db.Students.Include(x => x.Address).ToList();
            var students = _db.Students.ToList();
            foreach (var student in students)
            {
                var city = student.Address.City;
            }

            return Ok();
        }


        // Loop 
        [HttpGet]
        [Route("loop")]
        public ActionResult Loop()
        {
            var students = _db.Students.Take(5).ToList();

            foreach (var student in students)
            {
                var studentCourses = _db.CourseStudents
                    .Where(x => x.StudentId == student.Id)
                    .Select(x => x.Course)
                    .Distinct()
                    .ToList();
            }

            return Ok();
        }

        // Lazy Loading
        [HttpGet]
        [Route("loop2")]
        public ActionResult Loop2()
        {
            var students = _db.Students.Take(5).ToList();
            var courses = _db.CourseStudents
                .Where(x => students.Any(s => s.Id == x.StudentId))
                .ToList();

            foreach (var student in students)
            {
                var studentCourses = courses
                    .Where(x => x.StudentId == student.Id)
                    .Select(x => x.Course)
                    .Distinct()
                    .ToList();
            }

            return Ok();
        }

        [HttpGet]
        [Route("materialize")]
        public ActionResult Materialize()
        {
            var students = _db.Students
                .ToList()
                .Where(x => x.Name == "Student 1" || x.Name == "Student 2" || x.Name == "Student 3");


            return Ok();
        }
    }
}
