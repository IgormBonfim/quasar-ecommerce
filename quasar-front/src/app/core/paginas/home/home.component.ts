import { ProdutoBuscarRequest } from './../../../shared/models/requests/produtoBuscar.request';
import { ProdutoResponse } from './../../../shared/models/responses/produto.response';
import { CategoriaResponse } from './../../../shared/models/responses/categoria.response';
import { CategoriasService } from './../../../shared/services/categorias.service';
import { Component, OnInit } from '@angular/core';
import { ProdutosService } from 'src/app/shared/services/produtos.service';
import { PaginacaoResponse } from 'src/app/shared/models/responses/paginacao.response';
import { PaginacaoRequest } from 'src/app/shared/models/requests/paginacao.request';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  public categorias!: CategoriaResponse[];
  public nossosProdutos!: ProdutoResponse[];
  public outrosProdutos!: ProdutoResponse[];

  constructor(
    private categoriasService: CategoriasService,
    private produtosService: ProdutosService
    ) { }

  ngOnInit(): void {
    this.listarCategorias();
    this.listarProdutos();
  }

  listarCategorias() {
    let request = new PaginacaoRequest({
      quantidade: 5
    });

    this.categoriasService.listarCategorias(request).subscribe(
      (res: PaginacaoResponse<CategoriaResponse>) => {
        this.categorias = res.lista;
      }
    )
  }

  listarProdutos() {
    let request = new ProdutoBuscarRequest({});

    this.produtosService.listarProdutos(request).subscribe({
      next: (res: PaginacaoResponse<ProdutoResponse>) => {
        this.nossosProdutos = res.lista;
        this.outrosProdutos = res.lista.slice().reverse();
      }
    })
  }

}
