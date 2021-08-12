using BackEnd.Models;
using BackEnd.Models.Authentication;
using BackEnd.Models.Repository.UserRepository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using System;
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
        IWebHostEnvironment _appwebhostenvironment;
        private IMemoryCache cache;

        public AccountController(IUserRepository context, IMemoryCache _cache,IWebHostEnvironment appwebhostenvironment)
        {
            _context = context;
            cache = _cache;
            _appwebhostenvironment = appwebhostenvironment;

        }
        [HttpGet("/getuser/{userlogin}")]

        public User GetUser(string userlogin)
        {

            return _context.GetElement(userlogin);

        }
        
        [HttpGet("/users")]
        public IEnumerable<User> Get()
        {
            return _context.GetElements();
        }
        [HttpPost("/token")]
        public IActionResult Token(string login, string password)
        {

            var user = GetIdentity(login, password);

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
                username = user.Name
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

        public StatusCodeResult UploadAvatar(IFormFile photo,string username, string password)
        {

           
           User user= _context.UploadAvatar(username,password, photo.FileName);

            if (user != null)
            {
                _context.Upload(photo, _appwebhostenvironment);
                return Ok();
            }

            return NotFound();
            
           

        }

        [HttpPost(("/register"))]
        public async Task Register(string login, string email, string password,IFormFile avatar)
        {
            
            _context.RequestForVerification(ref cache,login, email, password, DateTime.UtcNow);
            

        

        }
            

        private ClaimsIdentity GetIdentity(string login, string password)
        {
            var pass = HashHelper.GetHashString(password);
            User user = _context.CheckUser(login,pass);
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
