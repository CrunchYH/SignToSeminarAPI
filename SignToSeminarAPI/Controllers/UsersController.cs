using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
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
        public User Get(int id)
        {
            using var context = new SignToSeminarDBContext();

            //Below doesn't work, but why?
            //var user = context.User.Where(u => u.id == id);

            var users = context.User.ToArray();
            foreach (var user in users)
            {
                if (user.id == id)
                {
                    return user;
                }
               
            }
            return null;
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
