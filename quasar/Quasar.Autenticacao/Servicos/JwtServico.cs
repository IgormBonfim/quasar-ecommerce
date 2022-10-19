using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Quasar.Autenticacao.Configuracoes;
using Quasar.Autenticacao.Servicos.Interfaces;
using Quasar.DataTransfer.Usuarios.Responses;

namespace Quasar.Autenticacao.Servicos
{
    public class JwtServico : IJwtServico
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly JwtOptions jwtOptions;

        public JwtServico(UserManager<IdentityUser> userManager, IOptions<JwtOptions> jwtOptions)
        {
            this.userManager = userManager;
            this.jwtOptions = jwtOptions.Value;
        }
        public async Task<UsuarioLoginResponse> GerarToken(IdentityUser usuario)
        {
            IList<Claim> tokenClaims = await ObterClaims(usuario);

            DateTime dataExpiracao = DateTime.Now.AddSeconds(jwtOptions.Expiration);

            var jwt = new JwtSecurityToken(
                issuer: jwtOptions.Issuer,
                audience: jwtOptions.Audience,
                claims: tokenClaims,
                notBefore: DateTime.Now,
                expires: dataExpiracao,
                signingCredentials: jwtOptions.SigningCredentials);

            var token = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new UsuarioLoginResponse
            (
                sucesso: true,
                token: token,
                dataExpiracao: dataExpiracao
            );
        }
        private async Task<IList<Claim>> ObterClaims(IdentityUser user)
        {
            var claims = await userManager.GetClaimsAsync(user);
            var roles = await userManager.GetRolesAsync(user);

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, DateTime.Now.ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()));

            foreach (var role in roles)
                claims.Add(new Claim("role", role));

            return claims;
        }
    }
}