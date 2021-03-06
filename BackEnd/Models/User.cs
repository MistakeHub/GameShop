using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace BackEnd.Models
{
    [Serializable]
    public class User:Delete
    {

        public int Id { get; }

        [Display(Name = "Логин")]
        [Required]
        public string Login { get; set; }

        [Display(Name = "Пароль")]
        [Required]
        public string Password { get; set; }

        [Display(Name = "Почтовый адресс")]
        [Required]
        public string Email { get; set; }

        [Display(Name = "Дата Регистрации")]
        [Required]
        public DateTime Dateofregistration { get; set; }


        public int? NumberOfPurchases { get; set; }
        public int? Idstatus { get; set; }
        public Statuse Status { get; set; }

        public int? Idrole { get; set; }
        public Role Role { get; set; }

        public int? Idcart { get; set; }
        public Cart Cart { get; set; }

        public int? Idavatar { get; set; }
        public Image Avatar { get; set; }

        public List<Mark>? Marks { get; set; } = new List<Mark>();

        public List<Comment>? Comments { get; set; } = new List<Comment>();

        public List<Transaction>? Transactions { get; set; } = new List<Transaction>();
    }
}
