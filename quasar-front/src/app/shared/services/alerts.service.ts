import { Injectable } from '@angular/core';
import { MessageService } from 'primeng/api';

@Injectable({
  providedIn: 'root'
})
export class AlertsService {

  constructor(private messageService: MessageService) { }

  adicionarAlerta(titulo: string, mensagem: string, tipo: AlertTypes) {
    this.messageService.add({
      severity: tipo,
      summary: titulo,
      detail: mensagem
    });
  }
}

export enum AlertTypes {
  SUCESSO = 'success',
  ERROR = 'error',
  INFO = 'info',
  AVISO = 'warn'
}
