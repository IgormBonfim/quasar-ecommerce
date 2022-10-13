using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.Dominio.Categorias.Entidades;

namespace Quasar.Dominio.Categorias.Repositorios
{
    public interface ICategoriasRepositorio
    {
        Categoria Inserir(Categoria categoria);
        Categoria Editar(Categoria categoria);
        void Deletar(Categoria categoria);
        Categoria Recuperar(int codigo);
        IQueryable<Categoria> Query();
    }
}