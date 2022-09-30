using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.Dominio.Ufs.Entidades;

namespace Quasar.Dominio.Ufs.Servicos.Interfaces
{
    public interface IUfsServico
    {
        Uf Validar (int idUf);
        IList<Uf> Listar (IQueryable<Uf> query);

        //criar metodo listar
    }
}