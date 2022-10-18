using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quasar.Dominio.Fornecedores.Entidades
{
    public class Fornecedor
    {
        // COLOCAR REGEX DE CNPJ E DE IE
        // DESCOMENTAR TUDO QUE É REFERENTE A FORNECEDOR EM PRODUTO 
        public virtual int Codigo { get; protected set; }
        public virtual string Nome { get; protected set; }
        public virtual string RazaoSocial { get; protected set; }
        public virtual string Cnpj { get; protected set; }
        public virtual string Ie { get; protected set; }

        public Fornecedor() { }
        
        public Fornecedor(string? nome, string? razaoSocial, string? cnpj, string? ie)
        {
            SetNome(nome);
            SetRazaoSocial(razaoSocial);
            SetCnpj(cnpj);
            SetIe(ie);
        }

        public virtual void SetCodigo(int? codigo)
        {
            if(!codigo.HasValue)
                throw new Exception("O código do Fornecedor é obrigatório");

            Codigo = codigo.Value;
        }

        public virtual void SetNome(string? nome)
        {
            // A excessão não cobre o tamanho do nome do fornecedor, pois podem existir fornecedores cujos nomes são siglas com menos que até mesmo 5 caractéres.
            if(string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O campo do fornecedor não pode ser nulo");

            Nome = nome;
        }

        public virtual void SetRazaoSocial(string? razaoSocial)
        {
            if(string.IsNullOrWhiteSpace(razaoSocial))
                throw new ArgumentException("O campo da razão social do fornecedor não pode ser nulo");

            RazaoSocial = razaoSocial;
        }

        public virtual void SetCnpj(string? cnpj)
        {
            if(string.IsNullOrWhiteSpace(cnpj))
                throw new ArgumentException("O CNPJ do fornecedor deve ser informado.");

            Cnpj = cnpj;
        }

        public virtual void SetIe (string? ie)
        {
            if(string.IsNullOrWhiteSpace(ie))
                throw new ArgumentException("A inscrição estadual deve ser informada");

            Ie = ie;    
        }
    }
}