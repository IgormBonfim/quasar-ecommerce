using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.Dominio.Ufs.Entidades;

namespace Quasar.Dominio.Cidades.Entidades
{
    public class Cidade
    {
        public virtual int Codigo { get; protected set; }
        public virtual string Nome { get; protected set; }
        public virtual Uf Uf { get; protected set; }
    
        public Cidade() { }

        public Cidade(string? nome, Uf? uf)
        {
            SetNome(nome);
            SetUf(uf);
        }

        public virtual void SetCodCidade(int? codigo)
        {
            if(!codigo.HasValue)
            {
                    throw new Exception("Código da cidade é obrigatório!");
            }
                Codigo = codigo.Value;
        }

        public virtual void SetNome(string? nome)
        {
            if(string.IsNullOrWhiteSpace(nome) || nome.Length < 3)
                throw new Exception("O campo nome deve possuir ao menos 3 caracteres");

            if(nome.Length > 100)
                throw new Exception("O campo nome deve possuir até 100 caracteres!");
            Nome = nome;
        }
        public virtual void SetUf(Uf uf)
        {
            Uf = uf;
        }
    }
}