using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.Dominio.Carrinhos.Entidades;
using Quasar.Dominio.Usuarios.Enumeradores;

namespace Quasar.Dominio.Usuarios.Entidades
{
    public class Cliente
    {
        public virtual int Codigo { get; protected set; }
        public virtual string Nome { get; protected set; }
        public virtual string? NomeFantasia { get; protected set; }
        public virtual string CpfCnpj { get; protected set; }
        public virtual string? InscricaoEstadual { get; protected set; }
        public virtual string? RazaoSocial { get; protected set; }
        public virtual TipoClienteEnum TipoCliente { get; protected set; }

        public Cliente() { }

        public Cliente(string? nome, string? nomeFantasia, string? cpfCnpj, string? inscricaoEstadual, string? razaoSocial, TipoClienteEnum? tipoCliente)
        {
            SetNome(nome);
            SetNomeFantasia(nomeFantasia);
            SetCpfCnpj(cpfCnpj);
            SetInscricaoEstadual(inscricaoEstadual);
            SetRazaoSocial(razaoSocial);
            SetTipoCliente(tipoCliente);
        }
        
        public virtual void SetCodigo(int? codigo)
        {
            if(!codigo.HasValue || codigo < 1)
                throw new Exception("O codigo é obrigatório");
            Codigo = codigo.Value;
        }

        public virtual void SetNome(string? nome )
        {
            if(string.IsNullOrWhiteSpace(nome) || nome.Length <= 5)
                throw new Exception("O campo nome deve conter no minímo 5 caracteres");
            if(nome.Length > 99)
                throw new Exception("O campo nome deve contar no máximo 100 caracteres");
            Nome = nome;
        }

        public virtual void SetNomeFantasia(string? nomeFantasia)
        {
            if(!string.IsNullOrWhiteSpace(nomeFantasia) && nomeFantasia.Length <= 2)
                throw new Exception("O campo nome fantasia deve contar no minímo 3 caracteres");
            NomeFantasia = nomeFantasia;
        }

        public virtual void SetCpfCnpj(string? cpfCnpj)
        {
            if(string.IsNullOrWhiteSpace(cpfCnpj) || cpfCnpj.Length < 11)
                throw new Exception("O campo CpfCnpj deve conter no minímo 11 caracteres");
            if(cpfCnpj.Length > 99)
                throw new Exception("O campo nome deve contar no máximo 14 caracteres");
            CpfCnpj = cpfCnpj;
        }

        public virtual void SetInscricaoEstadual(string? inscricaoEstadual)
        {
            if(!string.IsNullOrWhiteSpace(inscricaoEstadual) && inscricaoEstadual.Length != 9)
                throw new Exception("O campo Inscrição Estadual deve conter exatamente 9 caracteres");
            InscricaoEstadual = inscricaoEstadual;
        }

        public virtual void SetRazaoSocial(string? razaoSocial)
        {
            if(!string.IsNullOrWhiteSpace(razaoSocial) && razaoSocial.Length <= 2)
                throw new Exception("O campo Razão Social deve contar no minímo 3 caracteres");
            RazaoSocial = razaoSocial;
        }

        public virtual void SetTipoCliente(TipoClienteEnum? tipoCliente)
        {
            if(!tipoCliente.HasValue)
                throw new Exception("O campo TipoCliente é obrigatório");
            TipoCliente = tipoCliente.Value;
        }
    }
}