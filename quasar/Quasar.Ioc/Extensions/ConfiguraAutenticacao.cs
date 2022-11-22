using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Quasar.Dominio.Tokens.Entidades;
using Quasar.Dominio.Usuarios.Entidades;

namespace Quasar.Ioc.Extensions
{
    public static class ConfiguraAutenticacao
    {
        public static void AddAutenticacao(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentity<Usuario, Role>()
                .ExtendConfiguration()
                .AddRoles<Role>()
                .AddUserRole<UsuarioRole>()
                .AddNHibernateStores(x => x.SetSessionAutoFlush(false))
                .AddDefaultTokenProviders();

            IConfigurationSection jwtAppSettingOptions = configuration.GetSection("JwtOptions");
            string secretKey = configuration.GetSection("JwtOptions:SecurityKey").Value;
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));

            services.Configure<Jwt>(options =>
            {
                options.Issuer = jwtAppSettingOptions[nameof(Jwt.Issuer)];
                options.Audience = jwtAppSettingOptions[nameof(Jwt.Audience)];
                options.SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);
                options.Expiration = int.Parse(jwtAppSettingOptions[nameof(Jwt.Expiration)] ?? "0");
            });

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.SignIn.RequireConfirmedEmail = false;
            });

            TokenValidationParameters tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = configuration.GetSection("JwtOptions:Issuer").Value,

                ValidateAudience = true,
                ValidAudience = configuration.GetSection("JwtOptions:Audience").Value,

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = securityKey,

                RequireExpirationTime = true,
                ValidateLifetime = true,

                ClockSkew = TimeSpan.Zero
            };

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = tokenValidationParameters;
            });
        }
    }
}