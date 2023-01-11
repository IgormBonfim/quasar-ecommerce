import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormasPagamentoResponse } from 'src/app/shared/models/responses/formas-pagamento.response';
import { FormasPagamentoService } from 'src/app/shared/services/formas-pagamento.service';

@Component({
  selector: 'app-vendas-pagamento-pix',
  templateUrl: './vendas-pagamento-pix.component.html',
  styleUrls: ['./vendas-pagamento-pix.component.css']
})
export class VendasPagamentoPixComponent implements OnInit {

  public formaPagamento!: FormasPagamentoResponse;

  @Output() formaPagamentoEvent = new EventEmitter<number>();


  constructor(private formasPagamentoService: FormasPagamentoService) { }

  ngOnInit(): void {
    this.recuperarFormaPagamento();
  }

  recuperarFormaPagamento() {
    this.formasPagamentoService.recuperar(3).subscribe({
      next: (res: FormasPagamentoResponse) => {
        this.formaPagamento = res;
      }
    })
  }

  finalizar(codFormaPagamento: number) {
    this.formaPagamentoEvent.emit(codFormaPagamento);
  }
}
