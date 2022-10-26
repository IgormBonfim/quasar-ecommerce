using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quasar.Dominio.Enderecos.Entidades;
using Quasar.Dominio.Enderecos.Servicos.Interfaces;
using Quasar.Dominio.FormasPagamento.Entidades;
using Quasar.Dominio.FormasPagamento.Servicos.Interfaces;
using Quasar.Dominio.Produtos.Entidades;
using Quasar.Dominio.Usuarios.Entidades;
using Quasar.Dominio.Usuarios.Servicos.Interfaces;
using Quasar.Dominio.Vendas.Entidades;
using Quasar.Dominio.Vendas.Repositorios;
using Quasar.Dominio.Vendas.Servicos.Interfaces;

namespace Quasar.Dominio.Vendas.Servicos
{
    public class VendasServico : IVendasServico
    {

        private readonly IVendasRepositorio vendasRepositorio;
        private readonly IStatusVendasServico statusVendaServico;
        private readonly IFormasPagamentoServico formasPagamentoServico;
        private readonly IEnderecosServico enderecosServico;
        private readonly IUsuariosServico usuariosServico;

        public VendasServico(IVendasRepositorio vendasRepositorio, IStatusVendasServico statusVendaServico, IFormasPagamentoServico formasPagamentoServico, IEnderecosServico enderecosServico, IUsuariosServico usuariosServico)
        {
            this.vendasRepositorio = vendasRepositorio;
            this.statusVendaServico = statusVendaServico;
            this.formasPagamentoServico = formasPagamentoServico;
            this.usuariosServico = usuariosServico;
            this.enderecosServico = enderecosServico;
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

        public Venda Instanciar(int codStatusVenda, int codFormaPagamento, int codEndereco, string codUsuario)
        {
            StatusVenda statusVenda = statusVendaServico.Validar(codStatusVenda);
            FormaPagamento formaPagamento = formasPagamentoServico.Validar(codFormaPagamento);
            Endereco endereco = enderecosServico.Validar(codEndereco);
            Usuario usuario = usuariosServico.Validar(codUsuario);

            Venda venda = new Venda(statusVenda, formaPagamento, endereco, usuario);
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