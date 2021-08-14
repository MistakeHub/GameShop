using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using MimeKit;
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

       


        public void EditElement(int id, string value1, string value2, string value3, string value4)
        {
            throw new NotImplementedException();
        }

        public User CheckUser(string login, string password)
        {
            return _context.Users.Include(p => p.Role).Include(d => d.Status).Include(d => d.Marks).Include(d=>d.Avatar).FirstOrDefault(d=>d.Login==login && d.Password==password);
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
        public void RequestForVerification(ref IMemoryCache cache, string value1, string value2, string value3, DateTime value4, int value5, int value6)
        {
            value3 = HashHelper.GetHashString(value3);
            User user = new User() { Login = value1, Email = value2, Password = value3, Dateofregistration = value4, Cart = new Cart(),Idstatus=value5, Idrole=value6 };
            string key = HashHelper.GetHashString(value2);

            cache.Set(key, user, new MemoryCacheEntryOptions
            {

                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1)
            }) ;

                   EmailService service = new EmailService();
            service.SendEmailAsync(key, value2);
        }

        public User GetElement(string userlogin)
        {
            return _context.Users.Include(p => p.Role).Include(d => d.Status).Include(d => d.Marks).Include(d => d.Avatar).Include(d=>d.Comments).FirstOrDefault(d => d.Login == userlogin);
        }

        public User UploadAvatar(string login, string password,string filename)
        {
            User user = CheckUser(login, password);
            if (user != null)
            {
                user.Avatar = new Image() { Url = $"https://localhost:44303/getImage/Avatar/{filename}" };
                _context.Update(user);
                _context.SaveChanges();
            }

            return null;
        }
    }
}
