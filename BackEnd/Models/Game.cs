using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace BackEnd.Models
{
    [Serializable]
    public class Game
    {
        public int Id { get; }

        [Display(Name = "название игры")]
        public string Titleofgame { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Дата выхода")]
        public DateTime DateRelese { get; set; }

        public List<Manufacture> Manufactures { get; set; } = new List<Manufacture>();


        public List<Product> Products { get; set; } = new List<Product>();

        public int? Idseriesofgame { get; set; }

        public Serie Series { get; set; }


        public int? Idpublication { get; set; }

        public Publication Publication { get; set; }



        public List<Platform> Platforms { get; set; } = new List<Platform>();


   



        public List<Localization> Localizations { get; set; } = new List<Localization>();



        public List<Genre> Genres { get; set; } = new List<Genre>();


        public List<Country> RegionRestricts { get; set; } = new List<Country>();


     
      
    }
}
