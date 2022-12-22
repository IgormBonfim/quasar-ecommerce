import { ProdutoResponse } from './../../../shared/models/responses/produto.response';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { faSlidersH } from '@fortawesome/free-solid-svg-icons';
import { PaginacaoResponse } from 'src/app/shared/models/responses/paginacao.response';
@Component({
  selector: 'app-produtos-listagem',
  templateUrl: './produtos-listagem.component.html',
  styleUrls: ['./produtos-listagem.component.css'],
})
export class ProdutosListagemComponent implements OnInit {
  public filtro = faSlidersH;

  public produto!: PaginacaoResponse<ProdutoResponse>;

  produtoCard = new ProdutoResponse();

  constructor() {}

  ngOnInit(): void {}
}
