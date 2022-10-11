using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.Dominio.Estoques.Entidades;

namespace Quasar.Dominio.Estoques.Servicos.Interfaces
{
    public interface IEstoquesServico
    {
        Estoque Validar(int idEstoque);
        Estoque Inserir(Estoque Estoque);
        Estoque Editar(Estoque estoque);
        Estoque Instanciar(int qntEstoque);
        

    }
}