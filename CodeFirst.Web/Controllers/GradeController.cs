using CodeFirst.DataAccess;
using CodeFirst.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CodeFirst.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeController : ControllerBase
    {
        private readonly SchoolContext context;

        public GradeController()
        {
            context = new SchoolContext();
        }

        [HttpPost]
        public void Post([FromBody] Grade grade)
        {
            context.Grade.Add(grade);

            context.SaveChanges();
        }
    }
}
