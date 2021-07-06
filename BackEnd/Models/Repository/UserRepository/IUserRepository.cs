using BackEnd.Models.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models.Repository.UserRepository
{
    public interface IUserRepository { 



        IEnumerable<User> GetElements();
        User GetElement(string login, string password);
        void AddElement(string value1, string value2, string value3, DateTime value4, int value5, int value6);
        void EditElement(int id, string value1, string value2, string value3, string value4);
        void RemoveElement(int id);

    }
}
