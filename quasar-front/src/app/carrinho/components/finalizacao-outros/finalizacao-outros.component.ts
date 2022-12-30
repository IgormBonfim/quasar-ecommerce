import { CarrinhoResponse } from 'src/app/shared/models/responses/carrinho.response';
import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-finalizacao-outros',
  templateUrl: './finalizacao-outros.component.html',
  styleUrls: ['./finalizacao-outros.component.css']
})
export class FinalizacaoOutrosComponent implements OnInit {

  @Input()
  carrinhos!: CarrinhoResponse[];

  constructor() { }

  ngOnInit(): void {
  }


}
