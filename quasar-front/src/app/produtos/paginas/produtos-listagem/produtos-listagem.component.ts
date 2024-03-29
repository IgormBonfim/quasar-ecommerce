import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { faSlidersH } from '@fortawesome/free-solid-svg-icons';
import { PageChangedEvent } from 'ngx-bootstrap/pagination';
import { PaginacaoResponse } from 'src/app/shared/models/responses/paginacao.response';
import { ProdutosService } from 'src/app/shared/services/produtos.service';

import { ProdutoBuscarRequest } from './../../../shared/models/requests/produtoBuscar.request';
import { ProdutoResponse } from './../../../shared/models/responses/produto.response';


@Component({
  selector: 'app-produtos-listagem',
  templateUrl: './produtos-listagem.component.html',
  styleUrls: ['./produtos-listagem.component.css'],
})
export class ProdutosListagemComponent implements OnInit {
  public filtro = faSlidersH;

  public request = new ProdutoBuscarRequest({});
  public produtos!: PaginacaoResponse<ProdutoResponse>;
  public search!: string;
  public categoria!: string;

  constructor(
    private readonly produtosService: ProdutosService,
    private readonly activatedRoute: ActivatedRoute,
    private readonly router: Router
  ) {
    this.router.routeReuseStrategy.shouldReuseRoute = () => false;
  }

  ngOnInit(): void {
    this.search = this.activatedRoute.snapshot.queryParams['search'];
    this.categoria = this.activatedRoute.snapshot.queryParams['categoria']
    this.recuperarProdutos();
  }

  recuperarProdutos() {
    if (this.categoria) this.request.codCategoria = parseInt(this.categoria);
    if (this.search) this.request.nome = this.search;
    this.produtosService.listarProdutos(this.request).subscribe((produtos) => {
      this.produtos = produtos;
    });
  }

  trocarPagina(pagina: PageChangedEvent) {
    this.request.pagina = pagina.page;
    this.recuperarProdutos();
  }

  trocarQuantidade(quantidade: number) {
    this.request.quantidade = quantidade;
    this.recuperarProdutos();
  }
}
