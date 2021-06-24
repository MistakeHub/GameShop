using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace BackEnd.Models
{
    public class Product
    {

       public int? idgame { get; set; }
        [Display(Name ="Игра")]
       public Game Game { get; set; }



        public int? Idplatform { get; set; }
      
        public Platform Platform { get; set; }

        public int? Idmanufacture { get; set; }
      
        public Manufacture Manufacture { get; set; }

        public int? Idlocalization { get; set; }
       
        public Localization Localization { get; set; }

        public int? Idgenre { get; set; }
    
        public Genre Genre { get; set; }

        public int? Idregionrestrict { get; set; }
      
        public Country? RegionRestrict { get; set; }

        public int? Idgamecart { get; set; }

        public Gamecart? Gamecart { get; set; }

    
    }
}
