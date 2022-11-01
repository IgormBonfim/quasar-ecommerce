using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.Dominio.Carrinhos.Entidades;
using Quasar.Dominio.Produtos.Entidades;
using Quasar.Dominio.Usuarios.Entidades;

namespace Quasar.Dominio.Carrinhos.Servicos.Interfaces
{
    public interface ICarrinhosServico
    {
        Carrinho Validar(int codigo);
        Carrinho Inserir(Carrinho carrinho);
        Carrinho Instanciar(int? quantidade, int? codProduto, string? codUsuario);
        Carrinho Editar(Carrinho carrinho);
        void Deletar(int codigo);
    }
}