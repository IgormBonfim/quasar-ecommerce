import { HttpErrorResponse } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import { faCcAmex, faCcMastercard, faCcVisa, faPiedPiper } from '@fortawesome/free-brands-svg-icons';
import { faBagShopping, faCreditCard, faHouse, faUser } from '@fortawesome/free-solid-svg-icons';
import { PaginacaoRequest } from 'src/app/shared/models/requests/paginacao.request';
import { CarrinhoResponse } from 'src/app/shared/models/responses/carrinho.response';
import { PaginacaoResponse } from 'src/app/shared/models/responses/paginacao.response';
import { CarrinhosService } from 'src/app/shared/services/carrinhos.service';
import { SweetAlertService } from 'src/app/shared/services/sweet-alert.service';

import { ItemVendaInserirRequest } from '../../models/requests/itemVendaInserir.request';
import { VendaInserirRequest } from '../../models/requests/vendaInserir.request';
import { VendaInserirResponse } from '../../models/responses/vendaInserir.response';
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

  public pagamentoCartao: boolean = true;
  public pagamentoPix: boolean = false;
  public pagamentoBoleto: boolean = false;

  constructor(
    private readonly carrinhosService: CarrinhosService,
    private readonly sweetAlertService: SweetAlertService,
    private readonly vendasService: VendasService) { }

  @Input()
  carrinhos: CarrinhoResponse[] = [];

  valorTotal!: number;

  ngOnInit(): void {
    this.recuperarCarrinhos();
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
    console.log(this.venda);

    this.sweetAlertService.alertPersonalizado({
      title: 'Você confirma sua compra no valor de R$ ' + this.valorTotal + ' ?'  ,
      text: "You won't be able to revert this!",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
      if (result.isConfirmed) {
        this.vendasService.adicionar(this.venda).subscribe({
          next: (res: VendaInserirResponse) => {
            this.sweetAlertService.sucesso("carrinhos","Compra realizada com sucesso")
          },
          error: (httpError: HttpErrorResponse) => {
            this.sweetAlertService.excecao(httpError.error);
          }
        })

      }
    })
  }


}
