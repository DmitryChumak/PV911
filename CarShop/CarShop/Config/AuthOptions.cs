using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Config
{
    public class AuthOptions
    {
        public const string ISSUER = "CarShop";
        public const string AUDIENCE = "SomeClient";
        const string KEY = "LondonIsTheCapitalOfGreatBritain";
        public const int LIFETIME = 5;
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.Default.GetBytes(KEY));
        }
    }
}
