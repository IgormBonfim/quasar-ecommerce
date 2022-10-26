using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.Dominio.Cidades.Entidades;
using Quasar.Dominio.Cidades.Repositorios;
using Quasar.Dominio.Cidades.Servicos.Interfaces;

namespace Quasar.Dominio.Cidades.Servicos
{
    public class CidadesServico : ICidadesServico
    {
        private readonly ICidadesRepositorio cidadesRepositorio;
        public CidadesServico(ICidadesRepositorio cidadesRepositorio)
        {
            this.cidadesRepositorio = cidadesRepositorio;
        }

        public Cidade Validar(int codigo)
        {
            Cidade cidadeValidar = cidadesRepositorio.Recuperar(codigo);
            if (cidadeValidar == null)
                throw new Exception("Cidade não identificada.");
            return cidadeValidar;
        }
    }
}