using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models
{
    [Serializable]
    public class Role
    {
        public int Id { get; }
        
        [Display(Name = "Роль")]
        
        public string TitleofRole { get; set; }

        public List<User> Users { get; set; } = new List<User>();
    }
}
