using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SignToSeminarAPI.Entities
{
    public class User
    {
        [ForeignKey("Seminar")]


        public int id { set; get; }
        public string name { get; set; }

        public string email { get; set; }

        public IList<UserSeminar> userSeminars { get; set; }

    }
}
