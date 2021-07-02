using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models
{
    public class Mark
    {

        public int Id { get; set; }

        public int Countofrecommendation { get; set; }

        public int Countofnotrecommendation { get; set; }

        public int? idpublication { get; set; }

        public Publication Publication { get; set; }

       public List<User> Users { get; set; }
    }
}
