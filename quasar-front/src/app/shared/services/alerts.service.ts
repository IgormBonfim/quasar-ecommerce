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

  adicionarExcecao(mensagem: string) {
    let mensagens = mensagem.split("at");
    let mensagemTratada = mensagens[0].replace("System.Exception: ", "")

    this.adicionarAlerta(
      "Erro",
      mensagemTratada,
      AlertTypes.ERROR
    );
  }
}

export enum AlertTypes {
  SUCESSO = 'success',
  ERROR = 'error',
  INFO = 'info',
  AVISO = 'warn'
}
