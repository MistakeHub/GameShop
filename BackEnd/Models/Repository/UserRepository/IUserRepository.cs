using BackEnd.Models.Repository.GenericRepository;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models.Repository.UserRepository
{
    public interface IUserRepository { 



        IEnumerable<User> GetElements();
        User GetElement(string login, string password);
        void AddElement(User user);
        void EditElement(int id, string value1, string value2, string value3, string value4);
        void RemoveElement(int id);
        User AcceptVerification(ref IMemoryCache cache,string userkey, string email);
        void RequestForVerification(ref IMemoryCache  cache, string value1, string value2, string value3, DateTime value4, int value5=2, int value6=3);

    }
}
