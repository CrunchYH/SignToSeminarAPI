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
            var seminars = _context.Seminars.Include(s => s.day).ToArray();

            try
            {
                return seminars;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET: api/Seminars/5
        [HttpGet("{id}")]
        public Seminar GetSeminar(int id)
        {
            var seminar = _context.Seminars.Where(s => s.id == id).Include(s => s.speaker).Include(s => s.day).FirstOrDefault();
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
        public ActionResult<object> PostSeminar([FromBody] SeminarViewModel seminarVM)
        {
            var message = "New seminar added to list!";  
            
            var speaker = new Speaker { name = seminarVM.SpeakersName };
            _context.Speakers.Add(speaker);

            var stringDate = seminarVM.Date + " " + seminarVM.Time + ":00";
            var dateTimeDate = new Day { day = Convert.ToDateTime(stringDate) };
            _context.Days.Add(dateTimeDate);

            var seminar = new Seminar
            {
                name = seminarVM.name,
                description = seminarVM.description,
                speaker = speaker,
                day = dateTimeDate
            };
            _context.Seminars.Add(seminar);

            try
            {
                _context.SaveChanges();
            }
            catch (Exception)
            {
                message = "Seminar not saved, try again.";
                return (new { message });
            }
            return Ok(new { message });
        }

        // PUT: api/Seminars/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSeminar(int id, SeminarViewModel seminarVM)
        {
            var message = "Updated " + seminarVM.name + " successfully!";
            var stringDate = seminarVM.Date + " " + seminarVM.Time + ":00";
            var dateTimeDate = new Day { day = Convert.ToDateTime(stringDate) };
            
            var speaker = new Speaker();
            var existingSpeaker = _context.Speakers.Where(s => s.name == seminarVM.SpeakersName).FirstOrDefault();
            var existingSeminar = _context.Seminars.Where(s => s.id == id).FirstOrDefault();

            if (existingSpeaker == null)
            {
                speaker.name = seminarVM.SpeakersName;
                _context.Speakers.Add(speaker);
            }

            if (existingSeminar != null)
            {
                existingSeminar.name = seminarVM.name;
                existingSeminar.description = seminarVM.description;
                existingSeminar.speaker = speaker;
                existingSeminar.day = dateTimeDate;
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
        public ActionResult<object> Delete(int id)
        {
            var message = "Seminar deleted!";

            var seminar = new Seminar { id = id };
            _context.Seminars.Attach(seminar);
            _context.Seminars.Remove(seminar);

            try
            {
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            return Ok(new { message });
        }

        private bool SeminarExists(int id)
        {
            return _context.Seminars.Any(e => e.id == id);
        }
    }
}
