using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentNHibernate.AspNetCore.Identity;
using Quasar.Dominio.Carrinhos.Entidades;
using Quasar.Dominio.Produtos.Entidades;

namespace Quasar.Dominio.Usuarios.Entidades
{
    public class Usuario : IdentityUser<string>
    {
        public virtual string Codigo { get; protected set; }
        public virtual bool EmailConfirmed { get; protected set; }
        public virtual Cliente Cliente { get; protected set; }
        public virtual IList<Produto> Favoritos { get; protected set; }

        public Usuario() { }

        public Usuario(string? email, Cliente? cliente) 
        {
            SetId();
            SetEmail(email);
            SetCliente(cliente);
            SetUserName(cliente.CpfCnpj);
            SetEmailConfirmed(true);
        }

        public virtual void SetId()
        {
            Id = Guid.NewGuid().ToString();
        }

        public virtual void SetUserName(string? userName)
        {
            if(string.IsNullOrWhiteSpace(userName))
                throw new Exception("O campo email é obrigatório");
            UserName = userName;
        }

        public virtual void SetEmail(string? email)
        {
            if(string.IsNullOrWhiteSpace(email))
                throw new Exception("O campo email é obrigatório");
            Email = email;
        }

        public virtual void SetCliente(Cliente? cliente)
        {
            if(cliente == null)
                throw new Exception("O Cliente é obrigatório");
            Cliente = cliente;
        }

        public virtual void SetEmailConfirmed(bool emailConfirmed)
        {
            EmailConfirmed = emailConfirmed;
        }

    }
}