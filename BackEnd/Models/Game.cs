using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BackEnd.Models
{
    [Serializable]
    public class Game
    {
        public int Id { get; set; }

     
        public string Titleofgame { get; set; }

   
        public string Description { get; set; }

   
        public DateTime DateRelese { get; set; }

        public virtual List<Manufacture> Manufactures { get; set; } = new List<Manufacture>();


        public  List<Gameregionrestrict> Gameregionrestricts { get; set; } = new List<Gameregionrestrict>();

        public List<Gameplatform> Gameplatforms { get; set; } = new List<Gameplatform>();

        public List<Gamemanufacture> Gamemanufactures { get; set; } = new List<Gamemanufacture>();

        public List<Gamelocalization> Gamelocalizations { get; set; } = new List<Gamelocalization>();

        public List<Gamegenre> Gamegenres { get; set; } = new List<Gamegenre>();

        public int? Idseriesofgame { get; set; }

        public Serie Series { get; set; }


        public int? Idpublication { get; set; }

        public Publication Publication { get; set; }


   
        public virtual List<Platform> Platforms { get; set; } = new List<Platform>();


   



        public virtual List<Localization> Localizations { get; set; } = new List<Localization>();


       
        public virtual List<Genre> Genres { get; set; } = new List<Genre>();

       
        public virtual List<Country> RegionRestricts { get; set; } = new List<Country>();


     
      
    }
}
