using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quasar.Dominio.Ufs.Entidades
{
    public class Uf
    {


        public virtual int CodUf { get; protected set; }
        public virtual string Sigla { get; protected set; }
        public virtual string Nome { get; protected set; }

        public Uf()
        {

        }

        public Uf(int codUf, string sigla, string nome)
        {
            SetCodUf(codUf);
            SetSigla(sigla);
            SetNome(nome);
        }

        public virtual void SetCodUf(int? codUf)
        {
            if (!codUf.HasValue)
                throw new Exception("O código da UF tem que ser obrigatório!");
            CodUf = codUf.Value;
        }
        public virtual void SetSigla(string sigla)
        {
            throw new Exception("A sigla da UF tem que ser obrigatório!");
            Sigla = sigla;
        }
        public virtual void SetNome(string nome)
        {
            throw new Exception("A descrição da UF tem que ser obrigatório!");
            Nome = nome;
        }
    }
}