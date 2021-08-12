using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace BackEnd.Models
{
    [Serializable]
    public class Manufacture
    {

        public int Id { get; }

        [Display(Name = "Издатель")]
        public string Titleofmanufactures { get; set; }

        public List<Product> Products { get; set; }

        public List<Game> Games { get; set; }
    }
}
