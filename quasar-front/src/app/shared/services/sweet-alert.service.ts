import { Injectable } from '@angular/core';
import Swal, { SweetAlertIcon, SweetAlertOptions, SweetAlertResult } from 'sweetalert2';

@Injectable({
  providedIn: 'root'
})
export class SweetAlertService {

  constructor() { }

  private showAlert(
    mensagem: string,
    icone: SweetAlertIcon,
    titulo?: string
  ) {
    Swal.fire({
      title: titulo,
      text: mensagem,
      icon: icone,
      confirmButtonColor: '#000A61'
    })
  }

  public sucesso(mensagem: string, titulo?: string) {
    this.showAlert(mensagem, 'success', titulo);
  }

  public erro(mensagem: string, titulo?: string) {
    this.showAlert(mensagem, 'error', titulo);
  }

  public aviso(mensagem: string, titulo?: string) {
    this.showAlert(mensagem, 'warning', titulo)
  }

  public info(mensagem: string, titulo?: string) {
    this.showAlert(mensagem, 'info', titulo)
  }

  public pergunta(mensagem: string, titulo?: string) {
    this.showAlert(mensagem, 'question', titulo)
  }

  public alertPersonalizado(options: SweetAlertOptions): Promise<SweetAlertResult<any>> {
    return Swal.fire(options);
  }

  public finalizarCompra() {
    Swal.fire();
  }

  public excecao(mensagem: string, titulo?: string) {
    let mensagens = mensagem.split("\n");
    let mensagemTratada = mensagens[0].replace("System.Exception: ", "")

    this.erro(mensagemTratada, titulo);
  }
}
