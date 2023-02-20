using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace Quasar.Dominio.Tokens.Entidades
{
    public static class Jwt
    {
        public static string Issuer { get; set;  } = "https://quasar.vercel.app";
        public static string Audience { get; set; } = "QuasarUser";
        public static int Expiration { get; set; } = 3600;
        private static string Chave { get; set; } = "2006-KILAGQUASAR";

        public static string GetIssuer()
        {
            return Issuer;
        }

        public static string GetAudience()
        {
            return Audience;
        }

        public static int GetExpiration()
        {
            return Expiration;
        }

        private static string GetChave()
        {
            return Chave;
        }

        public static SymmetricSecurityKey GetSecurityKey()
        {
            string chave = GetChave();

            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Chave));
        }

        public static SigningCredentials GetSigningCredentials()
        {
            var securityKey = GetSecurityKey();

            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);
        }
    }
}