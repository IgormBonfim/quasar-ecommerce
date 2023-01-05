import { Component, Input, OnInit } from '@angular/core';
import { faCreditCard, faHeart, faMoneyBill, faShareNodes } from '@fortawesome/free-solid-svg-icons';

import { ProdutoResponse } from './../../../shared/models/responses/produto.response';

@Component({
  selector: 'app-produto-info',
  templateUrl: './produto-info.component.html',
  styleUrls: ['./produto-info.component.css']
})
export class ProdutoInfoComponent implements OnInit {

  public iconeCoracao = faHeart;
  public iconeShare = faShareNodes;
  public iconeDinheiro = faMoneyBill;
  public iconeCartao = faCreditCard;

  @Input()
  public produtoDetalhe!: ProdutoResponse;
  @Input()
  public produtoDisponivel!: boolean;

  constructor() { }

  ngOnInit(): void {
  }

}
