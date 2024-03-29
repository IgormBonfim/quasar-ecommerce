import { Component, OnInit } from '@angular/core';
import { CarrinhoResponse } from 'src/app/shared/models/responses/carrinho.response';
import { PaginacaoResponse } from 'src/app/shared/models/responses/paginacao.response';
import { ProdutoResponse } from 'src/app/shared/models/responses/produto.response';
import { ProdutosService } from 'src/app/shared/services/produtos.service';

import { PaginacaoRequest } from './../../../shared/models/requests/paginacao.request';
import { ProdutoBuscarRequest } from './../../../shared/models/requests/produtoBuscar.request';
import { CarrinhosService } from './../../../shared/services/carrinhos.service';

@Component({
  selector: 'app-carrinho',
  templateUrl: './carrinho.component.html',
  styleUrls: ['./carrinho.component.css']
})
export class CarrinhoComponent implements OnInit {
  public produtosCarrinho!: PaginacaoResponse<CarrinhoResponse>;
  public produtosRelacionados!: ProdutoResponse[];
  public request = new PaginacaoRequest({
    quantidade: 9999
  })


  constructor(
    private readonly carrinhosService: CarrinhosService,
    private readonly produtosService: ProdutosService,
    ) { }

  ngOnInit(): void {
    this.recuperarCarrinhos();
  }

  recuperarCarrinhos(){
    this.carrinhosService.listar(this.request).subscribe({
      next: (res: PaginacaoResponse<CarrinhoResponse>) => {
        this.produtosCarrinho = res;
        this.recuperarRelacionados();
      }
    })
  }

  recuperarRelacionados() {
    let request = new ProdutoBuscarRequest({
      quantidade: 3,
      codCategoria: this.produtosCarrinho.lista[0].produto.categoria.codigo || 1,
    })

    this.produtosService.listarProdutos(request).subscribe({
      next: (res: PaginacaoResponse<ProdutoResponse>) => {
        this.produtosRelacionados = res.lista;
      }
    });
  }
}
