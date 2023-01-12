import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { faCcAmex, faCcMastercard, faCcVisa } from '@fortawesome/free-brands-svg-icons';
import { FormasPagamentoResponse } from 'src/app/shared/models/responses/formas-pagamento.response';
import { FormasPagamentoService } from 'src/app/shared/services/formas-pagamento.service';

@Component({
  selector: 'app-vendas-pagamento-cartao',
  templateUrl: './vendas-pagamento-cartao.component.html',
  styleUrls: ['./vendas-pagamento-cartao.component.css']
})
export class VendasPagamentoCartaoComponent implements OnInit {
  visa = faCcVisa
  master = faCcMastercard
  amex = faCcAmex

  public formaPagamento!: FormasPagamentoResponse;

  @Output() formaPagamentoEvent = new EventEmitter<number>();

  constructor(private formasPagamentoService: FormasPagamentoService) { }

  ngOnInit(): void {
    this.recuperarFormaPagamento();
  }

  recuperarFormaPagamento() {
    this.formasPagamentoService.recuperar(1).subscribe({
      next: (res: FormasPagamentoResponse) => {
        this.formaPagamento = res;
      }
    })
  }

  finalizar(codFormaPagamento: number) {
    this.formaPagamentoEvent.emit(codFormaPagamento);
  }

}
