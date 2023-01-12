import { formatCurrency } from '@angular/common';
import { HttpErrorResponse } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { faCcAmex, faCcMastercard, faCcVisa, faPiedPiper } from '@fortawesome/free-brands-svg-icons';
import { faBagShopping, faCreditCard, faHouse, faUser } from '@fortawesome/free-solid-svg-icons';
import { PaginacaoRequest } from 'src/app/shared/models/requests/paginacao.request';
import { CarrinhoResponse } from 'src/app/shared/models/responses/carrinho.response';
import { EnderecoResponse } from 'src/app/shared/models/responses/endereco.response';
import { PaginacaoResponse } from 'src/app/shared/models/responses/paginacao.response';
import { UsuarioResponse } from 'src/app/shared/models/responses/usuario.response';
import { AuthService } from 'src/app/shared/services/auth.service';
import { CarrinhosService } from 'src/app/shared/services/carrinhos.service';
import { EnderecosService } from 'src/app/shared/services/enderecos.service';
import { SweetAlertService } from 'src/app/shared/services/sweet-alert.service';
import { UsuariosService } from 'src/app/shared/services/usuarios.service';

import { ItemVendaInserirRequest } from '../../models/requests/itemVendaInserir.request';
import { VendaInserirRequest } from '../../models/requests/vendaInserir.request';
import { VendaInserirResponse } from '../../models/responses/vendaInserir.response';
import { EtapasService } from '../../services/etapas.service';
import { VendasService } from '../../services/vendas.service';

@Component({
  selector: 'app-vendas-pagamento',
  templateUrl: './vendas-pagamento.component.html',
  styleUrls: ['./vendas-pagamento.component.css']
})
export class VendasPagamentoComponent implements OnInit {
  cartao = faCreditCard;
  usuario = faUser;
  casa = faHouse;
  visa = faCcVisa;
  master = faCcMastercard;
  amex = faCcAmex;
  line = faPiedPiper;
  bag = faBagShopping;

  public venda: VendaInserirRequest = new VendaInserirRequest({});
  public request = new PaginacaoRequest({
    quantidade: 9999
  })

  public endereco!: EnderecoResponse;
  public usuarioResponse!: UsuarioResponse;

  public pagamentoCartao: boolean = true;
  public pagamentoPix: boolean = false;
  public pagamentoBoleto: boolean = false;

  constructor(
    private readonly carrinhosService: CarrinhosService,
    private readonly sweetAlertService: SweetAlertService,
    private readonly vendasService: VendasService,
    private readonly enderecosService: EnderecosService,
    private readonly usuariosService: UsuariosService,
    private readonly etapasService: EtapasService,
    private readonly authService: AuthService,
    private readonly router: Router
    ) { }

  @Input()
  carrinhos: CarrinhoResponse[] = [];

  valorTotal!: number;

  ngOnInit(): void {
    this.recuperarCarrinhos();
    this.recuperarEndereco();
    this.recuperarDados();
  }

  trocarParaPix() {
    this.pagamentoBoleto = false;
    this.pagamentoCartao = false;
    this.pagamentoPix = true;
  }

  trocarParaCartao() {
    this.pagamentoBoleto = false;
    this.pagamentoPix = false;
    this.pagamentoCartao = true;
  }

  trocarParaBoleto() {
    this.pagamentoCartao = false;
    this.pagamentoPix = false;
    this.pagamentoBoleto = true;
  }

  calcularValorTotal() {
    let total = 0;

    this.carrinhos.forEach((carrinho) => {
      let valor = carrinho.produto.valor * carrinho.quantidade;

      total += valor;
    });

    this.valorTotal = total;
    return total;
  }

  recuperarCarrinhos(){
    this.carrinhosService.listar(this.request).subscribe({
      next: (res: PaginacaoResponse<CarrinhoResponse>) => {
        this.carrinhos = res.lista;
        this.construirVenda()
      }
    })
  }

  recuperarEndereco() {
    let codigoLocalStorage = localStorage.getItem("codigoEndereco") || "";
    let codigo = parseInt(codigoLocalStorage);

    this.enderecosService.recuperar(codigo).subscribe({
      next: (res: EnderecoResponse) => {
        this.endereco = res;
      }
    })
  }

  recuperarDados() {
    let codigoUsuario: string = this.authService.recuperarCodigo();

    this.usuariosService.recuperar(codigoUsuario).subscribe({
      next: (res: UsuarioResponse) => {
        this.usuarioResponse = res;
      }
    });
  }

  construirVenda() {
    this.venda.codStatusVenda = 1;

    let codEndereco = localStorage.getItem("codigoEndereco") || '';
    this.venda.codEndereco = parseInt(codEndereco);

    this.carrinhos.forEach(carrinho => {

      let itemVenda = new ItemVendaInserirRequest({
        codProduto: carrinho.produto.codigo,
        quantidade: carrinho.quantidade
      })

      this.venda.itens.push(itemVenda)
    });
  }

  public finalizarVenda(codFormaPagamento: number) {

    this.venda.codFormaPagamento = codFormaPagamento;

    this.sweetAlertService.alertPersonalizado({
      title: 'Você confirma sua compra no valor de ' + formatCurrency(this.valorTotal, "pt", "R$") + ' ?'  ,
      text: "As informações para realização do pagamento serão enviadas no email cadastrado.",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Confirmar',
      confirmButtonColor: '#000A61',
      cancelButtonText: 'Cancelar',
      cancelButtonColor: '#d33',
      reverseButtons: true
    }).then((result) => {
      if (result.isConfirmed) {
        this.vendasService.adicionar(this.venda).subscribe({
          next: (res: VendaInserirResponse) => {
            this.etapasService.irParaConcluido();
            this.sweetAlertService.sucesso("","Compra realizada com sucesso")
            this.sweetAlertService.alertPersonalizado({
              title: 'Pedido realizado com sucesso',
              icon: 'success',
            }).then(() => {
              this.etapasService.reiniciarEtapas();
              this.router.navigate(['/home']);
            });
          },
          error: (httpError: HttpErrorResponse) => {
            this.sweetAlertService.excecao(httpError.error);
          }
        })

      }
    })
  }


}
