using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.Dominio.Categorias.Entidades;

namespace Quasar.Dominio.Categorias.Servicos.Interfaces
{
    public interface ICategoriasServico
    {
        Categoria Validar (int id);
        Categoria Inserir(Categoria categoria);
        Categoria Instanciar(string nomeCategoria, string imgCategoria);
        Categoria Editar(Categoria categoria);
        IList<Categoria> Buscar(IQueryable<Categoria> query);
        void Deletar(int idCategoria);
    }
}