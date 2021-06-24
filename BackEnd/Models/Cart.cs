using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace BackEnd.Models
{
    public class Cart
    {
        [Display(Name = "ИД")]
        public int Id { get; }




        public int? Iduser { get; set; }
        public User User { get; set; }

        public List<Gamecart> Gamecart { get; set; }
    }
}
