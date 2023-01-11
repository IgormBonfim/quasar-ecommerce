import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { faLessThanEqual } from '@fortawesome/free-solid-svg-icons';

@Injectable({
  providedIn: 'root'
})
export class EtapasService {
  etapaEndereco: boolean = true;
  etapaPagamento: boolean = false;
  etapaConcluido: boolean = false;

  enderecoConcluido: boolean = false;
  pagamentoConcluido: boolean = false;

  constructor(private router: Router) { }

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
    this.router.navigate(['/vendas/concluido'])
  }

  reiniciarEtapas() {
    this.etapaEndereco = true;
    this.etapaPagamento = false;
    this.etapaConcluido = false;
    this.enderecoConcluido = false;
    this.pagamentoConcluido = false;
  }
}
