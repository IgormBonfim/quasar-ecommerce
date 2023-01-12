import { HttpErrorResponse } from '@angular/common/http';
import { VendaInserirResponse } from './../../models/responses/vendaInserir.response';
import { VendasService } from './../../services/vendas.service';
import { VendaInserirRequest } from '../../models/requests/vendaInserir.request';
import { SweetAlertService } from 'src/app/shared/services/sweet-alert.service';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormasPagamentoResponse } from 'src/app/shared/models/responses/formas-pagamento.response';

@Component({
  selector: 'app-botao-finalizar',
  templateUrl: './botao-finalizar.component.html',
  styleUrls: ['./botao-finalizar.component.css']
})
export class BotaoFinalizarComponent implements OnInit {

  @Input() formaPagamento!: FormasPagamentoResponse;
  @Input() vendaInserir!: VendaInserirRequest;

  @Output() finalizar = new EventEmitter<number>();

  constructor(
    private sweetAlertService: SweetAlertService,
    private vendasService: VendasService) { }

  ngOnInit(): void {
  }

  botaoFinalizar() {
    this.finalizar.emit(this.formaPagamento.codigo);
  }

}
