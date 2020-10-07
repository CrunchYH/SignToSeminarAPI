﻿using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignToSeminarAPI.Context;
using SignToSeminarAPI.Entities;
using SignToSeminarAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignToSeminarAPI.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("CORSPolicy")]
    [ApiController]
    public class SpeakersController : ControllerBase
    {
        private readonly SignToSeminarDBContext _context;

        public SpeakersController(SignToSeminarDBContext context)
        {
            _context = context;
        }

        // GET: api/SpeakersController
        [HttpGet]
        public IEnumerable<Speaker> Get()
        {
            var speakers = _context.Speakers.Include(s => s.seminars).ToArray();
            return speakers;

        }

        // GET api/SpeakersController/5
        [HttpGet("{id}")]
        public Speaker Get(int id)
        {
            var speaker = _context.Speakers.Where(o => o.id == id).FirstOrDefault();
            if (speaker != null)
                return speaker;
            else
                return null;
        }

        // POST api/<SpeakersController>
        [HttpPost]
        public void Post([FromBody] SpeakerViewModel speakerVM)
        {
            var speaker = new Speaker { name = speakerVM.name };
            _context.Speakers.Add(speaker);
            _context.SaveChanges();
        }


        // DELETE api/<SpeakersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var speaker = new Speaker { id = id };
            _context.Speakers.Attach(speaker);
            _context.Speakers.Remove(speaker);
            _context.SaveChanges();
        }
    }
}
