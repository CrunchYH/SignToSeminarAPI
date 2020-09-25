using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignToSeminarAPI.Entities
{
    public class Speaker
    {
        public int id { set; get; }
        public string name { get; set; }

        public virtual Seminar seminar { get; set; }
    }
}
