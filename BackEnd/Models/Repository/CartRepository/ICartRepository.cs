using BackEnd.Models.SaveToFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models.Repository.CartRepository
{
    public interface ICartRepository
    {
        Cart GetCart(string user);

        void AddToCart(string username,string game, int countof = 1, int sumof=0);
      
        void RemoveFromCart(string username,string game);

        void Purchase( int userid);

    }
}
