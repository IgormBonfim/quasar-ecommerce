using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.Dominio.Cidades.Entidades;

namespace Quasar.Dominio.Cidades.Servicos.Interfaces
{
    public interface ICidadesServico
    {
        Cidade Validar (int codigo);
        IList<Cidade> Listar(IQueryable<Cidade> query);
    }
}