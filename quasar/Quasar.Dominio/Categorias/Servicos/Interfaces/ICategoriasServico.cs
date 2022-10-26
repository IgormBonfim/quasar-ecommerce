using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.Dominio.Categorias.Entidades;

namespace Quasar.Dominio.Categorias.Servicos.Interfaces
{
    public interface ICategoriasServico
    {
        Categoria Validar (int codigo);
        Categoria Inserir(Categoria categoria);
        Categoria Instanciar(string nome, string imagem);
        Categoria Editar(Categoria categoria);
        void Deletar(int codigo);
    }
}