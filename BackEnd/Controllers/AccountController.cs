using AutoMapper;
using BackEnd.Models;
using BackEnd.Models.Authentication;
using BackEnd.Models.Repository.UserRepository;
using BackEnd.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BackEnd.Controllers
{
  
  
    public class AccountController : Controller
    {
        // GET: AccountController

        private IUserRepository _context;
       private IWebHostEnvironment _appwebhostenvironment;
        private IMemoryCache cache;
        private IMapper _mapper;
        public AccountController(IUserRepository context, IMemoryCache _cache,IWebHostEnvironment appwebhostenvironment, IMapper mapper)
        {
            _context = context;
            cache = _cache;
            _appwebhostenvironment = appwebhostenvironment;
            _mapper = mapper;

        }
        [HttpGet("/getuser/{userlogin}")]

        
        public UserViewModel GetUser(string userlogin)
        {

            var data = _context.GetElement(userlogin);
            var dataviewmodel = _mapper.Map<UserViewModel>(data);

            return dataviewmodel;

        }

        [HttpGet("/getfulluser/{id}")]
        [Authorize]
         public User GetFullUserById(int id)
        {
            return _context.GetElementById(id);
        }


        [HttpPut("/edituser/{id}")]
        [Authorize( Roles="Редактор,Администратор")]
        public StatusCodeResult EditUser(int id, IFormFile avatar, string login, string password, string email, string statuse, string role)
        {

            _context.EditElement(id, avatar, login, password, email, role, statuse, _appwebhostenvironment.WebRootPath);

            return Ok();

        }


        [Route("savetojson")]
        [HttpPost]
        [Authorize(Roles = "Редактор,Администратор")]
        public StatusCodeResult SaveToJson()
        {
            _context.SaveToJson();

            return Ok();

        }

        [Route("loadfromjson")]
        [Authorize(Roles = "Редактор,Администратор")]
        public StatusCodeResult LoadFromJson()
        {
            _context.LoadfromJson();

            return Ok();

        }

        [HttpGet("/users")]
        [Authorize(Roles = "Редактор,Администратор")]
        public (IEnumerable, int) Get()
        {
            int total;
            var data = _context.GetElements(out total);
            return (data,total);
        }
        
        [HttpPost("/token")]
        public IActionResult Token(string login, string password,int? optionalrole=null)
        {

            var user = GetIdentity(login, password,optionalrole);

            if (user == null) return BadRequest(new { error = "Неверный логин или пароль" });
            var now = DateTime.UtcNow;

            var jwt= new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: user.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                username = user.Name,
                role = user.Claims.ToArray()[1].Value
            };

            return Json(response);

        }

        [HttpPut("/verification")]

        public StatusCodeResult Verification(string userkey)
        {

            User user = _context.AcceptVerification(ref cache,userkey);

            return Ok();

        }

        [HttpPost("/uploadavatar/{username}")]
        [Authorize]
        public StatusCodeResult UploadAvatar(IFormFile photo,string username, string password)
        {

           
            _context.UploadAvatar(username,password, photo, _appwebhostenvironment.WebRootPath);

           

            return Ok();
            
           

        }

        [HttpPost("/restorerequest")]
        public IActionResult RestoreRequest(string email)
        {

            User user = _context.GetUserByEmail(email);
            string key = HashHelper.GetHashString(email);
            if (user != null)
            {
                cache.Set(key, user, new MemoryCacheEntryOptions
                {

                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(60)
                });
                EmailService.SendChangesInfoEmailAsync(email, $"<h1>Изменение пароля<h1><p> http://yourprojectname:8080/requestform/{key}");
                return Ok(new { key = key });

            }
            else
                return BadRequest(new { error = "Аккаунта с такой почтой не существует!" });


           



        }
        [HttpPost("/restore")]
        public IActionResult Restore(string restoreid, string password)
        {
            User user = null;

            cache.TryGetValue(restoreid,out user);

         
            _context.EditPassword(user, password);

            return Ok();

        }

        [HttpPost(("/register"))]
        public void Register(string login, string email, string password,IFormFile avatar, string status="Онлайн", string role="Пользователь")
        {
            
            _context.RequestForVerification(ref cache,login, email, password, DateTime.UtcNow, status, role);

        }
        [HttpPost(("/checkuserforrestore/{restoreid}"))]
        public IActionResult GetRestore(string restoreid)
        {
            User user = null;

           if(cache.TryGetValue(restoreid, out user)) return Ok();

            return BadRequest(new { error = "Ошибка" });

        }
      
        [Authorize]
        [HttpGet("/checkuser")]

        public IActionResult Check(string username, string password)
        {

            User user = _context.CheckUser(username, password);
            if (user == null)
            {

                return NotFound();

            }

            return Ok();

        }


        private ClaimsIdentity GetIdentity(string login, string password,int? optionalrole)
        {
           
            User user = _context.CheckUser(login,password,optionalrole);
            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.TitleofRole)
                };
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }

            // если пользователя не найдено
            return null;
        }
      
       

        
    }
}
