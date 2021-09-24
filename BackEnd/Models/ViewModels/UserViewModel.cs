using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models.ViewModels
{
    public class UserViewModel
    {
 

        public string Login { get; set; }

        public string Avatar { get; set; }

        public int CountofComments { get; set; }

        public string Statuse { get; set; }

        public string Role { get; set; }

        public int NumberOfPurchases { get; set; }
    }
}
