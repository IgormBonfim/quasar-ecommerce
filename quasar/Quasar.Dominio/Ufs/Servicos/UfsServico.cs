using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.Dominio.Ufs.Entidades;
using Quasar.Dominio.Ufs.Repositorios;
using Quasar.Dominio.Ufs.Servicos.Interfaces;

namespace Quasar.Dominio.Ufs.Servicos
{
    public class UfsServico : IUfsServico
    {

        private readonly IUfsRepositorio ufsRepositorio;

        public UfsServico(IUfsRepositorio ufsRepositorio)
        {
            this.ufsRepositorio = ufsRepositorio;
        }

        public IList<Uf> Listar(IQueryable<Uf> query)
        {
            return query.ToList();
        }

        public Uf Validar (int idUf)
    {
        Uf ufValidar = ufsRepositorio.Recuperar(idUf);
        if(ufValidar == null)
        throw new Exception("UF não encontrada.");
        return ufValidar;
    }
    }
}