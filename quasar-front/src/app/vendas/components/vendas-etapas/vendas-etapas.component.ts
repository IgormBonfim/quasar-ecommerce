import { Component, Input, OnInit } from '@angular/core';
import { faArrowRightLong, faCircleCheck, faCreditCard, faGripHorizontal, faRulerHorizontal, faShoppingCart, faTruck, faUser } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-vendas-etapas',
  templateUrl: './vendas-etapas.component.html',
  styleUrls: ['./vendas-etapas.component.css']
})
export class VendasEtapasComponent implements OnInit {
  carrinho = faShoppingCart
  usuario = faUser
  caminhao = faTruck
  cartao = faCreditCard
  concluido = faCircleCheck
  seta = faArrowRightLong

  @Input()
  dadosConcluido: boolean = false;
  @Input()
  enderecoConcluido: boolean = false;
  @Input()
  pagamentoConcluido: boolean = false

  constructor() { }

  ngOnInit(): void {
  }

  irParaEndereco() {
    this.dadosConcluido = true;
    console.log(this.dadosConcluido);
  }
  irParaPagamento() {
    this.enderecoConcluido = true;
    console.log(this.enderecoConcluido);
  }
  irParaConcluido() {
    this.pagamentoConcluido = true;
    console.log(this.pagamentoConcluido);
  }

}
