using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models.ViewModels
{
    public class CartViewModel
    {
        public List<Publication> Publication{ get; set; }

        public int Countof { get; set; }

        public double Sumof { get; set; }

        public string Image { get; set; }

    }
}
