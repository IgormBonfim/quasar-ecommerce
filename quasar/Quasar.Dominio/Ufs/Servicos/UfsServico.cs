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

        public Uf Validar(int codigo)
        {
            Uf ufValidar = ufsRepositorio.Recuperar(codigo);
            if (ufValidar == null)
                throw new Exception("UF não encontrada.");
            return ufValidar;
        }
    }
}