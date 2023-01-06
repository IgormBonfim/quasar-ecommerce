import { Component, Input, OnInit } from '@angular/core';
import { faArrowRightLong, faCircleCheck, faCreditCard, faGripHorizontal, faRulerHorizontal, faShoppingCart, faTruck, faUser } from '@fortawesome/free-solid-svg-icons';
import { EtapasService } from '../../services/etapas.service';

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
  etapaDados!: string;
  @Input()
  etapaEndereco!: string;
  @Input()
  etapaPagamento!: string;

  constructor(public etapasService: EtapasService) { }

  ngOnInit(): void {
  }
}
