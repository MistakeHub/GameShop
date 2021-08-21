using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BackEnd.Models
{
    [Serializable]
    public class Platform
    {
        public int Id { get; set; }

        [Display(Name = "Платформа")]
        [AllowNull]
        public string Titleofplatform { get; set; }
        [AllowNull]
        public  List<Gameplatform> Gameplatforms { get; set; } = new List<Gameplatform>();
        [AllowNull]
        public virtual List<Game> Games { get; set; } = new List<Game>();
    }
}
