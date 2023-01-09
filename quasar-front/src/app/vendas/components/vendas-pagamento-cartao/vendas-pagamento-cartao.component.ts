import { Component, OnInit } from '@angular/core';
import { faCcAmex, faCcMastercard, faCcVisa } from '@fortawesome/free-brands-svg-icons';

@Component({
  selector: 'app-vendas-pagamento-cartao',
  templateUrl: './vendas-pagamento-cartao.component.html',
  styleUrls: ['./vendas-pagamento-cartao.component.css']
})
export class VendasPagamentoCartaoComponent implements OnInit {
  visa = faCcVisa
  master = faCcMastercard
  amex = faCcAmex

  constructor() { }

  ngOnInit(): void {
  }

}
