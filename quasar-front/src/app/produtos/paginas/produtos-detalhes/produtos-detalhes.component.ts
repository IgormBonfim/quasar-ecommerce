import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProdutoBuscarRequest } from 'src/app/shared/models/requests/produtoBuscar.request';
import { EstoqueResponse } from 'src/app/shared/models/responses/estoque.response';
import { PaginacaoResponse } from 'src/app/shared/models/responses/paginacao.response';
import { EstoquesService } from 'src/app/shared/services/estoques.service';

import { ProdutoResponse } from './../../../shared/models/responses/produto.response';
import { ProdutosService } from './../../../shared/services/produtos.service';

@Component({
  selector: 'app-produtos-detalhes',
  templateUrl: './produtos-detalhes.component.html',
  styleUrls: ['./produtos-detalhes.component.css']
})
export class ProdutosDetalhesComponent implements OnInit {
  public produtoDetalhe!: ProdutoResponse;
  public produtosSimilares!: ProdutoResponse[];
  public produtoDisponivel!: boolean;
  public quantidadeProduto = 1;


  constructor(
    private produtosService: ProdutosService,
    private estoquesService: EstoquesService,
    private route: ActivatedRoute,
  ) { }

  ngOnInit(): void {
    this.route.params.subscribe(
      (params: any) => {
        const codProduto = params.codigo;
        this.recuperarProduto(codProduto);
        this.recuperarDoEstoque(codProduto);
      }
    )
  }

  private recuperarProduto(codigo: number) {
    this.produtosService.recuperarProduto(codigo).subscribe(
      (res: ProdutoResponse) => {
        this.produtoDetalhe = res
        this.listarSimilares(this.produtoDetalhe.categoria.codigo)
      }
    )
  }

  private recuperarDoEstoque(codigo: number) {
    this.estoquesService.recuperarEstoquePeloCodigoDoProduto(codigo).subscribe({
      next: (res: EstoqueResponse) => {
        this.produtoDisponivel = res.quantidade > 0;
      }
    })
  }

  listarSimilares(codCategoria: number) {
    let request = new ProdutoBuscarRequest({
      quantidade: 10,
      codCategoria: codCategoria
    });

    this.produtosService.listarProdutos(request).subscribe({
      next: (res: PaginacaoResponse<ProdutoResponse>) => {
        this.produtosSimilares = res.lista;
      }
    })
  }
}
