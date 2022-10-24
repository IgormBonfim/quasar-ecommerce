using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.Dominio.FormasPagamento.Entidades;
using Quasar.Dominio.FormasPagamento.Servicos.Interfaces;
using Quasar.Dominio.Produtos.Entidades;
using Quasar.Dominio.Usuarios.Entidades;
using Quasar.Dominio.Vendas.Entidades;
using Quasar.Dominio.Vendas.Repositorios;
using Quasar.Dominio.Vendas.Servicos.Interfaces;

namespace Quasar.Dominio.Vendas.Servicos
{
    public class VendasServico : IVendasServico
    {

        private readonly IVendasRepositorio vendasRepositorio;
        private readonly IStatusVendasServico statusVendaServico;
        private readonly IFormasPagamentoServico formaPagamentoServico;

        public VendasServico(IVendasRepositorio vendasRepositorio, IStatusVendasServico statusVendaServico, IFormasPagamentoServico formaPagamentoServico)
        {
            this.vendasRepositorio = vendasRepositorio;
            this.statusVendaServico = statusVendaServico;
            this.formaPagamentoServico = formaPagamentoServico;
        }

        public Venda Editar(Venda venda)
        {   
            Venda statusVendaEditar = Validar(venda.Codigo);

            if (venda.StatusVenda != statusVendaEditar.StatusVenda)
                statusVendaEditar.SetStatusVenda(venda.StatusVenda);

            return vendasRepositorio.Editar(venda);
        }

        public Venda Inserir(Venda venda)
        {
            int codigo = vendasRepositorio.Inserir(venda);
            venda.SetCodigo(codigo);
            return venda;
        }

        public Venda Instanciar(int codStatusVenda, int codFormaPagamento, int codEndereco, int codUsuario)
        {
            StatusVenda statusVenda = statusVendaServico.Validar(codStatusVenda);
            FormaPagamento formaPagamento = formaPagamentoServico.Validar(codFormaPagamento);
            Endereco endereco = enderecoServico.Validar(codEndereco);
            Usuario usuario = usuarioServico.Validar(codUsuario);

            Venda venda = new Venda(codStatusVenda, codFormaPagamento, codEndereco, codUsuario);
            return venda;
        }


        public Venda Validar(int codigo)
        {
             Venda vendaValidar = vendasRepositorio.Recuperar(codigo);
            if (vendaValidar == null)
                throw new Exception("Venda não encontada.");
            return vendaValidar;
        }
    }
}