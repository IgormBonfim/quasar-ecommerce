import { ProdutoResponse } from './../../../shared/models/responses/produto.response';
import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-produto-info',
  templateUrl: './produto-info.component.html',
  styleUrls: ['./produto-info.component.css']
})
export class ProdutoInfoComponent implements OnInit {

  @Input()
  public produtoDetalhe!: ProdutoResponse;
  @Input()
  public produtoDisponivel!: boolean;

  constructor() { }

  ngOnInit(): void {
  }

}
