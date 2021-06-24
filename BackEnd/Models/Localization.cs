using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace BackEnd.Models
{
    public class Localization
    {

        public int Id { get; }

        [Display(Name = "Язык")]
        public string Titleoflocalization { get; set; }
        public List<Game> Games { get; set; }
        public List<Product> Products { get; set; }
    }
}
