using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Models
{
    [Serializable]
    public class Publication
    {
        public int Id { get; }

        public int? idgame { get; set; }
        public Game Game { get; set; }

        [Display(Name = "Цена")]
        public double Price { get; set; }

       

        public List<Mark> Marks { get; set; }= new List<Mark>();

     
        public double? Rating { get; set; }


        public List<Cart> Carts { get; set; }
        public List<Gamecart> GameCarts { get; set; }

        public List<Image> Images { get; set; }
        [Display(Name = "Комментарии")]
        public List<Comment> Comments { get; set; }
        
        
    }
}
