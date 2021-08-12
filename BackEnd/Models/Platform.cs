using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace BackEnd.Models
{
    [Serializable]
    public class Platform
    {
        public int Id { get; }

        [Display(Name = "Платформа")]
        public string Titleofplatform { get; set; }

        public List<Product> Products { get; set; }
        public List<Game> Games { get; set; }
    }
}
