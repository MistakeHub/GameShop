using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models
{
    [Serializable]
    public class Country
    {
        [Display(Name = "ИД")]
        public int Id { get;  }

        [Display(Name = "Страна")]
        public string Titleofcountry { get; set; }
        public List<Game> Games { get; set; }
        public List<Product> Products { get; set; }

    }
}
