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
        public virtual int IdFornecedor { get; protected set; }
        public virtual string NomeFornecedor { get; protected set; }
        public virtual string RazaoSocialFornecedor { get; protected set; }
        public virtual string CnpjFornecedor { get; protected set; }
        public virtual string IeFornecedor { get; protected set; }

        public Fornecedor() { }
        
        public Fornecedor(string? nomeFornecedor, string? razaoSocialFornecedor, string? cnpjFornecedor, string? ieFornecedor)
        {
            SetNomeFornecedor(nomeFornecedor);
            SetRazaoSocialFornecedor(razaoSocialFornecedor);
            SetCnpjFornecedor(cnpjFornecedor);
            SetIeFornecedor(ieFornecedor);
        }

        public virtual void SetIdFornecedor(int? idFornecedor)
        {
            if(!idFornecedor.HasValue)
                throw new Exception("O código do Fornecedor é obrigatório");

            IdFornecedor = idFornecedor.Value;
        }

        public virtual void SetNomeFornecedor(string? nomeFornecedor)
        {
            // A excessão não cobre o tamanho do nome do fornecedor, pois podem existir fornecedores cujos nomes são siglas com menos que até mesmo 5 caractéres.
            if(string.IsNullOrWhiteSpace(nomeFornecedor))
                throw new ArgumentException("O campo do fornecedor não pode ser nulo");

            NomeFornecedor = nomeFornecedor;
        }

        public virtual void SetRazaoSocialFornecedor(string? razaoSocialFornecedor)
        {
            if(string.IsNullOrWhiteSpace(razaoSocialFornecedor))
                throw new ArgumentException("O campo da razão social do fornecedor não pode ser nulo");

            RazaoSocialFornecedor = razaoSocialFornecedor;
        }

        public virtual void SetCnpjFornecedor(string? cnpjFornecedor)
        {
            if(string.IsNullOrWhiteSpace(cnpjFornecedor))
                throw new ArgumentException("O CNPJ do fornecedor deve ser informado.");

            CnpjFornecedor = cnpjFornecedor;
        }

        public virtual void SetIeFornecedor (string? ieFornecedor)
        {
            if(string.IsNullOrWhiteSpace(ieFornecedor))
                throw new ArgumentException("A inscrição estadual deve ser informada");

            IeFornecedor = ieFornecedor;    
        }
    }
}