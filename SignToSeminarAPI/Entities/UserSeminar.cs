 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignToSeminarAPI.Entities
{
    public class UserSeminar
    {
        public int seminarId { get; set; }
        public Seminar seminar { get; set; }

        public int userId { get; set; }
        public User user { get; set; }
    }
}
