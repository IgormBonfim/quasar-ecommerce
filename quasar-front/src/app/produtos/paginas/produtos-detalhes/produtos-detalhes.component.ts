import { ProdutoResponse } from './../../../shared/models/responses/produto.response';
import { ProdutosService } from './../../../shared/services/produtos.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-produtos-detalhes',
  templateUrl: './produtos-detalhes.component.html',
  styleUrls: ['./produtos-detalhes.component.css']
})
export class ProdutosDetalhesComponent implements OnInit {
  public produtoDetalhe!: ProdutoResponse;
  public produtoDisponivel!: boolean;
  public quantidadeProduto = 1;


  constructor(
    private produtosService: ProdutosService,
    private route: ActivatedRoute,
  ) { }

  ngOnInit(): void {
    this.route.params.subscribe(
      (params: any) => {
        const codProduto = params.codigo;
        this.recuperarProduto(codProduto);
        this.produtoDisponivel = true;
      }
    )
  }

  private recuperarProduto(codigo: number) {
    this.produtosService.recuperarProduto(codigo).subscribe(
      (res: ProdutoResponse) => {
        this.produtoDetalhe = res
        console.log(this.produtoDetalhe);
      }
    )
  }
}
