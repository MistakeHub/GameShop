using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models
{
    [Serializable]
    public class Serie : Delete
    {

        public int Id { get; set; }

        [Display(Name = "Серия игр")]
        public string Titleofseries { get; set; }

        public  List<Game> Games { get; set; }
    }
}
