using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace BackEnd.Models
{
    public class Comment
    {
        public int Id { get; }
        [StringLength(300)]
        [Display(Name = "Комментарий")]
     
        public string Text { get; set; }
        [Display(Name ="Количество оцененных")]
        public int Countoflikes { get; set; }

        public int? Idpublication { get; set; }
        public Publication Publication { get; set; }

        public int? Iduser { get; set; }
        public User User { get; set; }
    }
}
