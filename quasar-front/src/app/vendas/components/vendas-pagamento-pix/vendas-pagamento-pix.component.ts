import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-vendas-pagamento-pix',
  templateUrl: './vendas-pagamento-pix.component.html',
  styleUrls: ['./vendas-pagamento-pix.component.css']
})
export class VendasPagamentoPixComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  botaoFinalizarPix() {
    localStorage.setItem("codigoFormaPagamento", "3")
  }

}
