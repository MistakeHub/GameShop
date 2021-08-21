using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models
{
    public class Gameplatform
    {


        public int? GameId { get; set; }

        public virtual Game Game { get; set; }

        public int? PlatformId { get; set; }

        public virtual Platform Platform { get; set; }
    }
}
