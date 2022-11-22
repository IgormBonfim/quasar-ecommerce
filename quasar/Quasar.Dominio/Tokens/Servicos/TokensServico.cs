using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Quasar.Dominio.Tokens.Entidades;
using Quasar.Dominio.Tokens.Servicos.Interfaces;
using Quasar.Dominio.Usuarios.Entidades;

namespace Quasar.Dominio.Tokens.Servicos
{
    public class TokensServico : ITokensServico
    {
        private readonly Jwt jwtOptions;
        private readonly UserManager<Usuario> userManager;
        private readonly IOptions<Jwt> jwtOptions1;

        public TokensServico(UserManager<Usuario> userManager, IOptions<Jwt> jwtOptions)
        {
            this.jwtOptions = jwtOptions.Value;
            this.userManager = userManager;
            jwtOptions1 = jwtOptions;
        }
        public async Task<string> GerarToken(Usuario usuario)
        {
            IList<Claim> tokenClaims = await ObterClamis(usuario);

            DateTime dataExpiracao = DateTime.Now.AddSeconds(jwtOptions.Expiration);

            JwtSecurityToken jwt = new JwtSecurityToken(
                issuer: jwtOptions.Issuer,
                audience: jwtOptions.Audience,
                claims: tokenClaims,
                notBefore: DateTime.Now,
                expires: dataExpiracao,
                signingCredentials: jwtOptions.SigningCredentials
            );

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        public async Task<IList<Claim>> ObterClamis(Usuario usuario)
        {
            IList<Claim> claims = await userManager.GetClaimsAsync(usuario);
            IList<string> roles = await userManager.GetRolesAsync(usuario);

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, usuario.Id));
            claims.Add(new Claim("codigoUsuario", usuario.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, usuario.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, DateTime.Now.ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()));

            foreach (var role in roles)
                claims.Add(new Claim("role", role));

            return claims;
        }
    }
}