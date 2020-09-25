using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignToSeminarAPI.Entities
{
    public class Day
    {
        public int id { get; set; }
        public DateTime day { get; set; }

        public IList<DaySeminar> daySeminars { get; set; }
    }
}
