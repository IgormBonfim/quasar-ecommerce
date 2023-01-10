import { Component, Input, OnInit } from '@angular/core';
import { ProdutoResponse } from 'src/app/shared/models/responses/produto.response';

@Component({
  selector: 'app-produto-especificacoes',
  templateUrl: './produto-especificacoes.component.html',
  styleUrls: ['./produto-especificacoes.component.css']
})
export class ProdutoEspecificacoesComponent implements OnInit {

  @Input()
  public produto!: ProdutoResponse;

  public descricao: boolean = true;

  constructor() { }

  ngOnInit(): void {
  }

}
