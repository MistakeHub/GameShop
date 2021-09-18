using BackEnd.Models.SaveToFile;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BackEnd.Models.Repository.UserRepository
{
    public class UserRepositoryImpl :FileSave<User>, IUserRepository
    {
        private shopContext _context;


        public UserRepositoryImpl(shopContext context)
        {
            this._context = context;

        }

        public void AddElement(User user)
        {
            Statuse status = _context.Statuses.FirstOrDefault(d => d.Id == user.Idstatus);
            Role role = _context.Roles.FirstOrDefault(d => d.Id == user.Idrole);

            Image image = _context.Images.First();

            user.Status = status;
            user.Role = role;
            user.Avatar = image;
            _context.Entry(status).State = EntityState.Modified;
            _context.Entry(role).State = EntityState.Modified;
            _context.Entry(image).State = EntityState.Modified;
            _context.Users.Add(user);
          
           
            _context.SaveChanges();

              



        }


        public User CheckUser(string login, string password, int? optionalrole)
        {
            
            if(optionalrole!=null)
            return _context.Users.Include(p => p.Role).Include(d => d.Status).Include(d => d.Marks).Include(d=>d.Avatar).FirstOrDefault(d=>d.Login==login && d.Password==HashHelper.GetHashString(password) && d.Idrole==optionalrole);
            else return _context.Users.Include(p => p.Role).Include(d => d.Status).Include(d => d.Marks).Include(d => d.Avatar).FirstOrDefault(d => d.Login == login && d.Password == HashHelper.GetHashString(password));
        }

        public IEnumerable<User> GetElements(out int total)

        {

            total = _context.Users.Count();
          return  _context.Users.Include(p=>p.Role).Include(d => d.Avatar).Include(d=>d.Status).Include(d=>d.Marks).ToList();
        }

        public User AcceptVerification(ref IMemoryCache cache,string userkey)
        {
            User user = null;
            if (cache.TryGetValue(userkey, out user)) 
                AddElement(user);
            else throw new Exception("Ошибка при регистрации");
        

           
     

            return user;
        }

        public void RemoveElement(int id)
        {
            throw new NotImplementedException();
        }
        // Здесь заносим юзера в кэш, и высылаем на почту подтверждение об регистрации
        public void RequestForVerification(ref IMemoryCache cache, string value1, string value2, string value3, DateTime value4, string status, string role)
        {
            value3 = HashHelper.GetHashString(value3);

            Role Role = _context.Roles.FirstOrDefault(d => d.TitleofRole == role); 
            Statuse Status = _context.Statuses.FirstOrDefault(d => d.Titleofstatuse == status);


            User user = new User() { Login = value1, Email = value2, Password = value3, Dateofregistration = value4, Cart = new Cart(),Idstatus=Status.Id,  Idrole=Role.Id };
            string key = HashHelper.GetHashString(value2);

            cache.Set(key, user, new MemoryCacheEntryOptions
            {

                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1)
            }) ;

               
            EmailService.SendVerifyEmailAsync(key, value2);
        }

        public User GetElement(string userlogin)
        {
            return _context.Users.Include(p => p.Role).Include(d => d.Status).Include(d => d.Marks).Include(d => d.Avatar).Include(d=>d.Comments).FirstOrDefault(d => d.Login == userlogin);
        }

        public User UploadAvatar(string login, string password, IFormFile photo, string path )
        {
            User user = CheckUser(login, password,null);
            Upload(photo, path);

          
            if (user != null)
            {
              
                user.Avatar = new Image() { Url = $"https://localhost:44303/getImage/Avatar/{photo.FileName}", Filename=photo.FileName };
                _context.Update(user);
                _context.SaveChanges();
            }

            return null;
        }

        public void EditElement(int id, IFormFile avatar, string login, string password, string email, string role, string statuse,string path)
        {
            User User = _context.Users.Include(d => d.Status).Include(d => d.Role).Include(d=>d.Avatar).FirstOrDefault(d => d.Id == id);
            Role Role = _context.Roles.FirstOrDefault(d => d.TitleofRole == role);
            Statuse Statuse = _context.Statuses.FirstOrDefault(d => d.Titleofstatuse == statuse);


            User.Email = email;
            if (User.Login != login)
            {
                EmailService.SendChangesInfoEmailAsync(email, $"<h1> Дорогой {User.Login}</h1> <p> Администрация сайта уведомляет вас о том, что ваш логин был изменён на {login} </p>");
                User.Login = login;
               

            }

            if (User.Password != password)
            {
                EmailService.SendChangesInfoEmailAsync(email, $"<h1> Дорогой {User.Login}</h1> <p> Администрация сайта уведомляет вас о том, что ваш пароль  был изменён на {password} </p>");
             
                User.Password = HashHelper.GetHashString(password); ;

           
            }
           
     
            _context.Entry(Role).State = EntityState.Modified;
            _context.Entry(Statuse).State = EntityState.Modified;

           

             
                User.Avatar = new Image() { Url = $"https://localhost:44303/getImage/Avatar/{avatar.FileName}", Filename = avatar.FileName };
                Upload(avatar, path);

           
            User.Role = Role;
            User.Status = Statuse;
            _context.Update(User);
            _context.SaveChanges();

           


        }

        public User GetElementById(int id)
        {
            return _context.Users.Include(p => p.Role).Include(d => d.Status).Include(d => d.Marks).Include(d => d.Avatar).Include(d => d.Comments).FirstOrDefault(d => d.Id == id);
        }

        public async void SaveToJson()
        {
            await SaveToJson("Users.json", _context.Users);
        }

        public void LoadfromJson()
        {
            IEnumerable<User> users = LoadFromJson("Users.json");
        }

        public User GetUserByEmail(string Email)
        {
            return _context.Users.FirstOrDefault(d => d.Email == Email);
        }

        public void EditPassword(User userr, string password)
        {
            User user = userr;

            user.Password = HashHelper.GetHashString(password);

            _context.Users.Update(user);

            _context.SaveChanges();
        }
    }
}
