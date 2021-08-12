using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace BackEnd.Models
{
    [Serializable]
    public class Cart
    {
        [Display(Name = "ИД")]
        public int Id { get; }


        


        public int? Iduser { get; set; }
        public User User { get; set; }

        public int? Countof { get; set; }

        public double? Sum { get; set; }

        public List<Publication> Publications { get; set; } = new List<Publication>();

        public List<Gamecart> Gamecart { get; set; } = new List<Gamecart>();
    }
}
