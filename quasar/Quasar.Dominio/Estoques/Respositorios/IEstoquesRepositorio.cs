using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.Dominio.Estoques.Entidades;

namespace Quasar.Dominio.Estoques.Respositorios
{
    public interface IEstoquesRepositorio
    {
        Estoque Inserir(Estoque estoque);
        Estoque Editar(Estoque estoque);
        IQueryable<Estoque> Query();
        Estoque Recuperar(int codigo);
    }
}