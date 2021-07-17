using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models.Repository.CartRepository
{
    public class CartRepositoryImpl : ICartRepository
    {

        private shopContext _context;

        public CartRepositoryImpl(shopContext Context)
        {
            _context = Context;

        }
        public  void AddToCart(string username, string gamee, int countof = 1, int sumof = 0)
        {

            Cart cart = _context.Carts.AsNoTrackingWithIdentityResolution().Include(d=>d.User).AsNoTrackingWithIdentityResolution().Include(d=>d.Publications).AsNoTrackingWithIdentityResolution().FirstOrDefault(p => p.User.Login.Equals(username));
            Publication game = _context.Publications.AsNoTrackingWithIdentityResolution().Include(d => d.Game).AsNoTrackingWithIdentityResolution().FirstOrDefault(d => d.Game.Titleofgame.Equals(gamee));



            cart.Publications.Add(game);
            cart.Countof = countof;
            cart.Sum = sumof;
            
            _context.Carts.Update(cart);
     
            _context.Entry(cart).State = EntityState.Modified;
           
            _context.SaveChanges();
            foreach (var item in _context.Gamecarts)
            {

                _context.Entry(item).State = EntityState.Detached;

            }
            _context.Gamecarts.Add(new Gamecart { Cart = cart, Publication = game });

            _context.SaveChanges();

            SumPrice(cart.User.Login);
        }

        public Cart GetCart(string user)
        {

            SumPrice(user);
            return _context.Carts.Include(d=>d.Publications).ThenInclude(d=>d.Game).Include(p=>p.Publications).ThenInclude(d=>d.Images).Include(d=>d.User).Single(d=>d.User.Login.Equals(user));
        }

        public async void RemoveFromCart(string user,string gamee)
        {
            Cart cart = _context.Carts.AsNoTracking().Include(d => d.User).AsNoTracking().Include(d => d.Publications).AsNoTracking().FirstOrDefault(p => p.User.Login.Equals(user));
            Publication game = _context.Publications.AsNoTracking().Include(d => d.Game).AsNoTracking().FirstOrDefault(d => d.Game.Titleofgame.Equals(gamee));
            int idgame = game.Id;
            cart.Publications.Remove(game);
          

            _context.Carts.Update(cart);
         
            _context.Entry(cart).State = EntityState.Detached;
            _context.Entry(game).State = EntityState.Detached;
             _context.SaveChanges();

           
         
            _context.Gamecarts.RemoveRange(_context.Gamecarts.AsNoTracking().Where(d => d.idpublication == idgame));



         _context.SaveChanges();

        }

        private void SumPrice(string user)
        {


            var item = _context.Carts.AsNoTrackingWithIdentityResolution().Include(d => d.Publications).AsNoTrackingWithIdentityResolution().Include(d => d.User).AsNoTrackingWithIdentityResolution().FirstOrDefault(d=>d.User.Login.Equals(user));
            
        
                
                    item.Sum = item.Publications.Sum(d => d.Price) * item.Countof;
                    _context.Carts.Update(item);
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
                


            

        } 
    }
}
