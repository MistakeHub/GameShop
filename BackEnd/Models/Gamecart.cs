using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models
{
    public class Gamecart
    {

        public int? idpublication { get; set; }

        public Publication Publication { get; set; }

        public int? idcart { get; set; }

        public Cart Cart { get; set; }
    }
}
