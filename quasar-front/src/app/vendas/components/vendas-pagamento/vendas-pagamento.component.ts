import { faBagShopping, faCreditCard, faHouse, faUser } from '@fortawesome/free-solid-svg-icons';
import { Component, OnInit } from '@angular/core';
import { faCcAmex, faCcMastercard, faCcVisa, faPiedPiper } from '@fortawesome/free-brands-svg-icons';

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

  public pagamentoCartao: boolean = true;
  public pagamentoPix: boolean = false;
  public pagamentoBoleto: boolean = false;
  constructor() { }


  ngOnInit(): void {
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


}
