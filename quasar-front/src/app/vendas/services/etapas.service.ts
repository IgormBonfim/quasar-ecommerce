import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { faLessThanEqual } from '@fortawesome/free-solid-svg-icons';

@Injectable({
  providedIn: 'root'
})
export class EtapasService {
  etapaDados: boolean = true;
  etapaEndereco: boolean = true;
  etapaPagamento: boolean = false;
  etapaConcluido: boolean = false;

  dadosConcluido: boolean = true;
  enderecoConcluido: boolean = false;
  pagamentoConcluido: boolean = false;

  constructor(private router: Router) { }

  irParaEndereco() {
    this.etapaDados = false;
    this.dadosConcluido = true;
    this.etapaEndereco = true;
    this.router.navigate(['/vendas/endereco'])
  }

  irParaPagamento() {
    this.etapaEndereco = false;
    this.enderecoConcluido = true;
    this.etapaPagamento = true;
    this.router.navigate(['/vendas/pagamento'])
  }

  irParaConcluido() {
    this.etapaPagamento = false;
    this.pagamentoConcluido = true;
    this.etapaConcluido = true;
  }
}
