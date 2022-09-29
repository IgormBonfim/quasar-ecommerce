using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.Dominio.StatusVendas.Entidades;

namespace Quasar.Dominio.StatusVendas.Servicos.Interfaces
{
    public interface IStatusVendasServico
    {
        StatusVenda Validar(int id);
        StatusVenda Inserir(StatusVenda statusVenda);
        StatusVenda Instanciar(string? descricaoStatusVenda);
        StatusVenda Editar(StatusVenda statusVenda);
        StatusVenda Deletar(int idStatusVenda);

    }
}