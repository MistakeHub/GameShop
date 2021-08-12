using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace BackEnd.Models
{
    [Serializable]
    public class Statuse
    {

        public int Id { get; }

        [Display(Name = "Статус")]
        public string Titleofstatuse { get; set; }
        public List<User> Users { get; set; } = new List<User>();
    }
}
