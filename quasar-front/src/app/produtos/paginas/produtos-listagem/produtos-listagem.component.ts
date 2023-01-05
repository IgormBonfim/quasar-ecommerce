import { ProdutoBuscarRequest } from './../../../shared/models/requests/produtoBuscar.request';
import { Component, OnInit } from '@angular/core';
import { faSlidersH } from '@fortawesome/free-solid-svg-icons';
import { PaginacaoRequest } from 'src/app/shared/models/requests/paginacao.request';
import { PaginacaoResponse } from 'src/app/shared/models/responses/paginacao.response';
import { ProdutosService } from 'src/app/shared/services/produtos.service';

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

  produtoCard = new ProdutoResponse();

  constructor(private readonly produtosService: ProdutosService) {}

  ngOnInit(): void {
    this.recuperarProdutos();
  }
  recuperarProdutos() {
    this.produtosService.listarProdutos(this.request).subscribe((produtos) => {
      this.produtos = produtos;
    });
  }

  trocarPagina(pagina: number) {
    this.request.pagina = pagina;
    this.recuperarProdutos();
  }

  trocarQuantidade(quantidade: number) {
    this.request.quantidade = quantidade;
    this.recuperarProdutos();
  }
}
