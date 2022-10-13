using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.Dominio.Produtos.Entidades;

namespace Quasar.Dominio.Produtos.Servicos.Interfaces
{
    public interface IEspecificacoesServico
    {
        Especificacao Validar (int cod);
        Especificacao Inserir (Especificacao especificacao);
        Especificacao Instanciar (string? posicao, string? cor, DateTime? ano, string? veiculo);
        Especificacao Editar (Especificacao especificacao);
        void Deletar (int codEspecificacao);
    }
}