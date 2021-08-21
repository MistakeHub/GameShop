using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BackEnd.Models
{
    [Serializable]
    public class Genre
    {
        public int Id { get; set; }

        [Display(Name ="Жанр")]
    
        public string Titleofgenre { get; set; }
     
        public List<Gamegenre> Gamegenres { get; set; } = new List<Gamegenre>();
    
        public virtual List<Game> Games { get; set; } = new List<Game>();
    }
}
