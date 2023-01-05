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
  public categorias!: any;
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
    this.categoriasService.listarCategorias().subscribe(
      (res: CategoriaResponse[]) => {
        this.categorias = res;
        console.log(this.categorias);
      }
    )
  }

  listarProdutos() {
    let request = new PaginacaoRequest({});

    this.produtosService.listarProdutos(request).subscribe({
      next: (res: PaginacaoResponse<ProdutoResponse>) => {
        this.nossosProdutos = res.lista;
        this.outrosProdutos = res.lista;
      }
    })
  }

}
