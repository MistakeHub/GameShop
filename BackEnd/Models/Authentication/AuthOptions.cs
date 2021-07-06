using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BackEnd.Models.Authentication
{
    public class AuthOptions
    {

        public const string ISSUER = "MyAuthServer"; // издатель токена
        public const string AUDIENCE = "MyAuthClient"; // потребитель токена
        const string KEY = "mysupersecret_secretkey!123";   // ключ для шифрации
        public const int LIFETIME = 39999; // время жизни токена - 1 минута
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
