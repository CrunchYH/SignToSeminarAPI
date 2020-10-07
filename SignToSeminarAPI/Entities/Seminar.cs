using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SignToSeminarAPI.Entities
{
    public class Seminar
    {
        [ForeignKey("Speaker")]


        public int id { get; set; }
        public string name { get; set; }

        public string description { get; set; }

        public int SeminarOfSpeakerId { get; set; }

        public Speaker speaker { get; set; }

        public IList<DaySeminar> daySeminars { get; set; }

        public IList<UserSeminar> userSeminars { get; set; } 
    }
}
