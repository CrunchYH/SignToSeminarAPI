﻿using System;
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
        public IEnumerable<Seminar> Get()
        {
            var seminars = _context.Seminars.ToArray();
            return seminars;
        }

        // GET: api/Seminars/5
        [HttpGet("{id}")]
        public Seminar Get(int id)
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
        public void Post([FromBody] SeminarViewModel seminarVM)
        {
            var seminar = new Seminar { name = seminarVM.name, description = seminarVM.description,
                                        SeminarOfSpeakerId = seminarVM.SeminarOfSpeakerId};
            _context.Seminars.Add(seminar);
            _context.SaveChanges();
        }

        // PUT: api/Seminars/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
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
    }
}
