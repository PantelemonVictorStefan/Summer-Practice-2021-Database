using System;
using System.Collections.Generic;
using System.Linq;
using CodeFirst.DataAccess;
using CodeFirst.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly SchoolContext context;

        public CourseController()
        {
            context = new SchoolContext();
        }

        [HttpGet]
        public IEnumerable<Course> Get()
        {
            return context.Course.ToList();
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public Course Get(Guid id)
        {
            Course course = context.Course
                .Include(c=>c.Students)
                .FirstOrDefault(s => s.Id == id);

            course?.Students.ToList().ForEach((student) => { student.Courses = null; });

            return course;
        }

        [HttpPost]
        public void Post([FromBody] Course course)
        {
            context.Course.Add(course);

            context.SaveChanges();
        }

    }
}
