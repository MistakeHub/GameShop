using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BackEnd.Models
{
    [Serializable]
    public class Manufacture : Delete
    {

        public int Id { get; set; }

        [Display(Name = "Издатель")]
        [AllowNull]
        public string Titleofmanufactures { get; set; }
        [AllowNull]
        public virtual List<Gamemanufacture> Gamemanufactures { get; set; } = new List<Gamemanufacture>();
        [AllowNull]
        public virtual List<Game> Games { get; set; } = new List<Game>();
    }
}
