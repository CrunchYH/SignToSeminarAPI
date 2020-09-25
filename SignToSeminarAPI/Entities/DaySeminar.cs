using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignToSeminarAPI.Entities
{
    public class DaySeminar
    {
        public int seminarId { get; set; }
        public Seminar seminar { get; set; }

        public int dayId { get; set; }
        public Day day { get; set; }
    }
}
