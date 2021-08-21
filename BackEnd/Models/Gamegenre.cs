using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models
{
    public class Gamegenre
    {


        public int? GameId { get; set; }

        public virtual Game Game { get; set; }





        public int? GenreId { get; set; }

        public virtual Genre Genre { get; set; }
    }
}
