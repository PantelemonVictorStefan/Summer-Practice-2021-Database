using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using CodeFirst.DataAccess;
using CodeFirst.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodeFirst.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly SchoolContext context;

        public StudentController()
        {
            context = new SchoolContext();
        }

        // GET: api/<StudentController>
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return context.Students.ToList();
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public Student Get(Guid id)
        {
            Student student = context.Students
                .Include(s=>s.Address)
                .Include(s => s.Grades)
                .FirstOrDefault(s => s.Id == id);

            if (student?.Address != null)
            {
                student.Address.Student = null;
            }

            student?.Grades.ToList().ForEach((grade) => { grade.Student = null; });

            return student;
        }

        // POST api/<StudentController>
        [HttpPost]
        public void Post([FromBody] Student student)
        {
            context.Students.Add(student);

            context.SaveChanges();
        }

        // PUT api/<StudentController>/5
        [HttpPut]
        public void Put([FromBody] Student student)
        {
            if (!student.Id.HasValue)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return;
            }

            context.Students.Update(student);

            context.SaveChanges();
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            var studentToDelete = context.Students.First(s => s.Id == id);

            context.Students.Remove(studentToDelete);

            context.SaveChanges();
        }
    }
}
