using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models
{
    public class Gamemanufacture
    {

        public int? GameId { get; set; }

        public virtual Game Game { get; set; }

        public int? ManufactureId { get; set; }

        public virtual Manufacture Manufacture { get; set; }
    }
}
