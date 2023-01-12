import { FormasPagamentoResponse } from './../../../shared/models/responses/formas-pagamento.response';
import { FormasPagamentoService } from './../../../shared/services/formas-pagamento.service';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-vendas-pagamento-boleto',
  templateUrl: './vendas-pagamento-boleto.component.html',
  styleUrls: ['./vendas-pagamento-boleto.component.css']
})
export class VendasPagamentoBoletoComponent implements OnInit {

  public formaPagamento!: FormasPagamentoResponse;

  @Output() formaPagamentoEvent = new EventEmitter<number>();

  constructor(private formasPagamentoService: FormasPagamentoService) { }

  ngOnInit(): void {
    this.recuperarFormaPagamento();
  }

  recuperarFormaPagamento() {
    this.formasPagamentoService.recuperar(2).subscribe({
      next: (res: FormasPagamentoResponse) => {
        this.formaPagamento = res;
      }
    })
  }

  finalizar(codFormaPagamento: number) {
    this.formaPagamentoEvent.emit(codFormaPagamento);
  }

}
