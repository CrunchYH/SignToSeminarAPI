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
    [EnableCors("CORSPolicy")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly SignToSeminarDBContext _context;

        public UsersController(SignToSeminarDBContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public IEnumerable<User> GetAllUsers()
        {
            var users = _context.Users.ToArray();
            
            return users;

        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public User GetUser(int id)
        {
            var user = _context.Users.Where(u => u.id == id).FirstOrDefault();
            if (user != null)
            {
                return user;
            }
            else
                return null;
        }

        // POST: api/Users
        [HttpPost]
        public void PostUser([FromBody] UserViewModel userVM)
        {
            var user = new User { name = userVM.name, email = userVM.email };
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpeaker(int id, UserViewModel userVM)
        {

            var existingUser = _context.Users.Where(u => u.id == id).FirstOrDefault();

            if (existingUser != null)
            {
                existingUser.name = userVM.name;
                existingUser.email = userVM.email;
            }
            else
            {
                return BadRequest();
            }

            _context.Entry(existingUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void DeleteUser(int id)
        {
            var user = new User { id = id };
            _context.Users.Attach(user);
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.id == id);
        }
    }
}
