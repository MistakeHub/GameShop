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
        User GetElementById(int id);
        User CheckUser(string login, string password, int? optionRole=null);
        void AddElement(User user);
        void EditElement(int id, IFormFile avatar, string login, string password, string email, string role, string statuse,string path);
        void RemoveElement(int id);
        User AcceptVerification(ref IMemoryCache cache,string userkey);
        void RequestForVerification(ref IMemoryCache  cache, string value1, string value2, string value3, DateTime value4, string status="Онлайн", string role="Пользователь");
        User UploadAvatar(string login, string password,IFormFile photo, string path);
        void SaveToJson();
        void LoadfromJson();
        

    }
}
