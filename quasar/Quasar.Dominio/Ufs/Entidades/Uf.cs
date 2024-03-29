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

        public Uf(string sigla, string nome)
        {
            SetSigla(sigla);
            SetNome(nome);
        }

        public virtual void SetCodigo(int? codigo)
        {
            if (!codigo.HasValue || codigo <= 0)
                throw new Exception("O código da UF tem que ser obrigatório!");
            Codigo = codigo.Value;
        }
        public virtual void SetSigla(string sigla)
        {
            if (sigla.Length != 2 || sigla == null)
                throw new Exception("A sigla da UF tem que ser obrigatório!");
            Sigla = sigla;
        }
        public virtual void SetNome(string nome)
        {
            if (String.IsNullOrWhiteSpace(nome) || nome.Length <= 3)
                throw new Exception("A descrição da UF tem que ser obrigatório!");
            Nome = nome;
        }
    }
}