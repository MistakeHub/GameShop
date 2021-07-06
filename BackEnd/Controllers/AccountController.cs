using BackEnd.Models;
using BackEnd.Models.Authentication;
using BackEnd.Models.Repository.UserRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public AccountController(IUserRepository context)
        {
            _context = context;


        }
        [HttpGet]
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

        private ClaimsIdentity GetIdentity(string login, string password)
        {
            User user = _context.GetElement(login,password);
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
