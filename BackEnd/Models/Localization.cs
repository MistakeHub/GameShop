using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BackEnd.Models
{
    [Serializable]
    public class Localization
    {

        public int Id { get; set; }

        [Display(Name = "Язык")]
        [AllowNull]
        public string Titleoflocalization { get; set; }
        [AllowNull]
        public virtual List<Game> Games { get; set; } = new List<Game>();
        [AllowNull]
        public  List<Gamelocalization> Gamelocalizations { get; set; } = new List<Gamelocalization>();
    }
}
