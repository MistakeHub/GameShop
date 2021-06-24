using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace BackEnd.Models
{
    public class Gamecart
    {


        [Display(Name = "Сумма")]
        public double Sumprice { get; set; }

        public int Idproduct { get; set; }
        public  Product Product { get; set; }



        public int idcart { get; set; }
        public Cart Cart { get; set; }
    }
}
