using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignToSeminarAPI.Context;
using SignToSeminarAPI.Entities;
using SignToSeminarAPI.Models;

namespace SignToSeminarAPI.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("CORSPolicy")]
    [ApiController]
    public class SeminarsController : ControllerBase
    {
        private readonly SignToSeminarDBContext _context;

        public SeminarsController(SignToSeminarDBContext context)
        {
            _context = context;
        }

        // GET: api/Seminars
        [HttpGet]
        public IEnumerable<Seminar> GetAllSeminars()
        {
            var seminars = _context.Seminars.ToArray();
            return seminars;
        }

        // GET: api/Seminars/5
        [HttpGet("{id}")]
        public Seminar GetSeminar(int id)
        {
            var seminar = _context.Seminars.Where(s => s.id == id).FirstOrDefault();
            if (seminar != null)
            {
                return seminar;
            }
            else
            {
                return null;
            }
        }

        // POST: api/Seminars
        [HttpPost]
        public void PostSeminar([FromBody] SeminarViewModel seminarVM)
        {
            var seminar = new Seminar { name = seminarVM.name, description = seminarVM.description,
                                        SeminarOfSpeakerId = seminarVM.SeminarOfSpeakerId};
            _context.Seminars.Add(seminar);
            _context.SaveChanges();
        }

// PUT: api/Seminars/5
[HttpPut("{id}")]
        public async Task<IActionResult> PutSeminar(int id, SeminarViewModel seminarVM)
        {
            var existingSeminar = _context.Seminars.Where(s => s.id == id).FirstOrDefault();

            if (existingSeminar != null)
            {
                existingSeminar.name = seminarVM.name;
                existingSeminar.SeminarOfSpeakerId = seminarVM.SeminarOfSpeakerId;
                existingSeminar.description = seminarVM.description;
            }
            else
            {
                return BadRequest();
            }
            _context.Entry(existingSeminar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeminarExists(id))
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
        public void Delete(int id)
        {
            var seminar = new Seminar { id = id };
            _context.Seminars.Attach(seminar);
            _context.Seminars.Remove(seminar);
            _context.SaveChanges();
        }

        private bool SeminarExists(int id)
        {
            return _context.Seminars.Any(e => e.id == id);
        }
    }
}
