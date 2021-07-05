using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Models
{
    public class Publication
    {
        public int Id { get; }

        public int? idgame { get; set; }
        public Game Game { get; set; }

        [Display(Name = "Цена")]
        public double Price { get; set; }

       

        public List<Mark> Marks { get; set; }= new List<Mark>();

     
        public double? Rating { get; set; } 

        [Display(Name = "Комментарии")]
        public List<Comment> Comments { get; set; }
        
        
    }
}
