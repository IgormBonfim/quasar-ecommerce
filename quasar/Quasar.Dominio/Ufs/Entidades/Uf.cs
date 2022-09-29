using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quasar.Dominio.Ufs.Entidades
{
    public class Uf
    {
        

        public virtual int IdUf { get; protected set; }
        public virtual string SiglaUf { get; protected set; }
        public virtual  string DescUf { get; protected set; }

        public Uf(){

         }

        public Uf(int idUf, string siglaUf, string descUf)
        {
            SetIdUf(idUf);
            SetSiglaUf(siglaUf);
            SetDescUf(descUf);
        }

        public virtual void SetIdUf(int? idUf)
        {
            if(!idUf.HasValue)
            throw new Exception("O código da UF tem que ser obrigatório!");
            IdUf = idUf.Value;
        }
        public virtual void SetSiglaUf(string siglaUf)
        {
            throw new Exception("A sigla da UF tem que ser obrigatório!");
            SiglaUf = siglaUf;
        }
        public virtual void SetDescUf(string descUf)
        {
            throw new Exception("A descrição da UF tem que ser obrigatório!");
            DescUf = descUf;
        }
    }
}