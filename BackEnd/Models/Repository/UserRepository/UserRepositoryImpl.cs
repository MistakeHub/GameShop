using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BackEnd.Models.Repository.UserRepository
{
    public class UserRepositoryImpl : IUserRepository
    {
        private shopContext _context;

        public UserRepositoryImpl(shopContext context)
        {
            this._context = context;

        }

        public void AddElement(string value1, string value2, string value3, DateTime value4, int value5, int value6)
        {
            throw new NotImplementedException();
        }

        public void EditElement(int id, string value1, string value2, string value3, string value4)
        {
            throw new NotImplementedException();
        }

        public User GetElement(string login, string password)
        {
            return _context.Users.Include(p => p.Role).Include(d => d.Status).Include(d => d.Marks).FirstOrDefault(d=>d.Login==login && d.Password==password);
        }

        public IEnumerable<User> GetElements()
        {
          return  _context.Users.Include(p=>p.Role).Include(d=>d.Status).Include(d=>d.Marks).ToList();
        }

        public void RemoveElement(int id)
        {
            throw new NotImplementedException();
        }
    }
}
