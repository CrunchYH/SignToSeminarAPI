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
        
        public Day day { get; set; }

        public int SeminarOfDayId { get; set; }

        public IList<UserSeminar> userSeminars { get; set; } 
    }
}
