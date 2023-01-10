import { Component, Input, OnInit } from '@angular/core';
import { faCcAmex, faCcMastercard, faCcVisa, faPiedPiper } from '@fortawesome/free-brands-svg-icons';
import { faBagShopping, faCreditCard, faHouse, faUser } from '@fortawesome/free-solid-svg-icons';
import { PaginacaoRequest } from 'src/app/shared/models/requests/paginacao.request';
import { CarrinhoResponse } from 'src/app/shared/models/responses/carrinho.response';
import { PaginacaoResponse } from 'src/app/shared/models/responses/paginacao.response';
import { CarrinhosService } from 'src/app/shared/services/carrinhos.service';
import { ProdutosService } from 'src/app/shared/services/produtos.service';

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

  public produtosCarrinho!: PaginacaoResponse<CarrinhoResponse>;
  public request = new PaginacaoRequest({
    quantidade: 9999
  })

  public pagamentoCartao: boolean = true;
  public pagamentoPix: boolean = false;
  public pagamentoBoleto: boolean = false;

  constructor(private readonly carrinhosService: CarrinhosService,
    private readonly produtosService: ProdutosService) { }

  @Input()
  teste: CarrinhoResponse[] = [];

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

    this.teste.forEach((carrinho) => {
      let valor = carrinho.produto.valor * carrinho.quantidade;

      total += valor;
    });
    return total;
  }

  recuperarCarrinhos(){
    this.carrinhosService.listar(this.request).subscribe({
      next: (res: PaginacaoResponse<CarrinhoResponse>) => {
        this.teste = res.lista;
        console.log(res);
      }
    })
  }


}
