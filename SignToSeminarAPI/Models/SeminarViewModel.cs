using SignToSeminarAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignToSeminarAPI.Models
{
    public class SeminarViewModel
    {
        public string name { get; set; }
        public string description { get; set; }
        public int SeminarOfSpeakerId { get; set; }
        public int SeminarOfDayId { get; set; }
        public string SpeakersName { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
    }
}
