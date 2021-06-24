using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace BackEnd.Models
{
    public class Game
    {
        public int Id { get; }

        [Display(Name = "название игры")]
        public string Titleofgame { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Дата выхода")]
        public DateTime DateRelese { get; set; }


        public int? Idseriesofgame { get; set; }

        public Serie Series { get; set; }


        public int? Idpublication { get; set; }

        public Publication Publication { get; set; }



        public List<Platform> Platforms { get; set; }

      



        public List<Localization> Localizations { get; set; }

 

        public List<Genre> Genres { get; set; }

      
        public List<Country> RegionRestricts { get; set; }

        public List<Product> Products { get; set; }

        public List<Manufacture> Manufactures { get; set; }
      
    }
}
