using BackEnd.Models.Repository.GenericRepository;
using BackEnd.Models.SaveToFile;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models.Repository.UserRepository
{
    public interface IUserRepository { 



        IEnumerable<User> GetElements(out int total);
        User GetElement(string userlogin);
        User CheckUser(string login, string password);
        void AddElement(User user);
        void EditElement(int id, string value1, string value2, string value3, string value4);
        void RemoveElement(int id);
        User AcceptVerification(ref IMemoryCache cache,string userkey);
        void RequestForVerification(ref IMemoryCache  cache, string value1, string value2, string value3, DateTime value4, int value5=2, int value6=3);
        User UploadAvatar(string login, string password,IFormFile photo, string path);
        

    }
}
