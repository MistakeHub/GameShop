using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BackEnd.Models
{
    [Serializable]
    public class Country
    {
        [Display(Name = "ИД")]
        public int Id { get;  }

        [Display(Name = "Страна")]
        [AllowNull]
        public string Titleofcountry { get; set; }

        [AllowNull]
        public  List<Gameregionrestrict> Gameregionrestricts { get; set; } = new List<Gameregionrestrict>();
        [AllowNull]
        public virtual List<Game> Games { get; set; } = new List<Game>();

    }
}
