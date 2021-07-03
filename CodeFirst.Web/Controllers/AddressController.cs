using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CodeFirst.DataAccess;
using CodeFirst.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodeFirst.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly SchoolContext context;

        public AddressController()
        {
            context = new SchoolContext();
        }

        // POST api/<AddressController>
        [HttpPost]
        public void Post([FromBody] Address address)
        {
            context.Address.Add(address);

            context.SaveChanges();
        }

        // DELETE api/<AddressController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            var addressToDelete = context.Address.First(a => a.Id == id);

            context.Remove(addressToDelete);

            context.SaveChanges();
        }
    }
}
