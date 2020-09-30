using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignToSeminarAPI.Context;
using SignToSeminarAPI.Entities;

namespace SignToSeminarAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // GET: api/Users
        [HttpGet]
        public IEnumerable<User> Get()
        {
            //Bra?
            using var context = new SignToSeminarDBContext();
            var users = context.User.ToArray();
            return users;

        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return id.ToString();
        }

        // POST: api/Users
        [HttpPost]
        public void Post([FromBody] UserViewModel userVM)
        {
            using (var context = new SignToSeminarDBContext())
            {
                var user = new User { name = userVM.name, email = userVM.email };
                context.User.Add(user);
                context.SaveChanges(); 
            }
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (var context = new SignToSeminarDBContext())
            {
                var user = new User { id = id };
                context.User.Attach(user);
                context.User.Remove(user);
                context.SaveChanges();
            }
        }
    }
}
