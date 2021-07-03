using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using CodeFirst.DataAccess;
using CodeFirst.Entities;
using Microsoft.AspNetCore.Mvc;

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
            return context.Students.FirstOrDefault(s => s.Id == id);
        }

        // POST api/<StudentController>
        [HttpPost]
        public void Post([FromBody] Student student)
        {
            if (student.Id.HasValue)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;

                return;
            }

            context.Students.Add(student);

            context.SaveChanges();
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
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
            var studentToDelete = context.Students.FirstOrDefault(s => s.Id == id);

            if (studentToDelete == null)
            {
                Response.StatusCode = (int)HttpStatusCode.NotFound;

                return;
            }

            context.Students.Remove(studentToDelete);

            context.SaveChanges();
        }
    }
}
