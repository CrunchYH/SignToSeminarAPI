using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignToSeminarAPI.Context;
using SignToSeminarAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignToSeminarAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpeakersController : ControllerBase
    {
        // GET: api/SpeakersController
        [HttpGet]
        public IEnumerable<Speaker> Get()
        {
            using var context = new SignToSeminarDBContext();
            var speakers = context.Speakers.Include(c => c.seminars).ToArray();
            return speakers;

        }

        // GET api/SpeakersController/5
        [HttpGet("{id}")]
        public Speaker Get(int id)
        {
            using (var context = new SignToSeminarDBContext())
            {
                var speaker = context.Speakers.Where(o => o.id == id).FirstOrDefault();
                if (speaker != null)
                    return speaker;
                else
                    return null;
            }
        }

        // POST api/<SpeakersController>
        [HttpPost]
        public void Post([FromBody] Speaker speaker)
        {
            using (var context = new SignToSeminarDBContext())
            {
                context.Speakers.Add(speaker);
                context.SaveChanges();
            }
        }


        // DELETE api/<SpeakersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (var context = new SignToSeminarDBContext())
            {
                var speaker = new Speaker { id = id };
                context.Speakers.Attach(speaker);
                context.Speakers.Remove(speaker);
                context.SaveChanges();
            }
        }
    }
}
