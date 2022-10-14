using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quasar.Dominio.Ufs.Entidades
{
    public class Uf
    {


        public virtual int Codigo { get; protected set; }
        public virtual string Sigla { get; protected set; }
        public virtual string Nome { get; protected set; }

        public Uf()
        {

        }

        public Uf(int codigo, string sigla, string nome)
        {
            SetCodigo(codigo);
            SetSigla(sigla);
            SetNome(nome);
        }

        public virtual void SetCodigo(int? codigo)
        {
            if (!codigo.HasValue)
                throw new Exception("O código da UF tem que ser obrigatório!");
            Codigo = codigo.Value;
        }
        public virtual void SetSigla(string sigla)
        {
            if (sigla.Length < 1)
                throw new Exception("A sigla da UF tem que ser obrigatório!");
            Sigla = sigla;
        }
        public virtual void SetNome(string nome)
        {
            if (nome.Length <= 3)
                throw new Exception("A descrição da UF tem que ser obrigatório!");
            Nome = nome;
        }
    }
}