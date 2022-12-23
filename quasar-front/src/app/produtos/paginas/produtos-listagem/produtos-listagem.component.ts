import { ProdutosService } from './../../services/produtos.service';
import { ProdutoResponse } from './../../../shared/models/responses/produto.response';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { faSlidersH } from '@fortawesome/free-solid-svg-icons';
// import { PaginacaoResponse } from 'src/app/shared/models/responses/paginacao.response';
@Component({
  selector: 'app-produtos-listagem',
  templateUrl: './produtos-listagem.component.html',
  styleUrls: ['./produtos-listagem.component.css'],
})
export class ProdutosListagemComponent implements OnInit {
  public filtro = faSlidersH;

  // public request = new PaginacaoRequest<ProdutoResponse>({});
  // public produto!: PaginacaoResponse<ProdutoResponse>;

  produtoCard = new ProdutoResponse();

  constructor(private readonly produtosService: ProdutosService) {}

  ngOnInit(): void {
    // this.recuperarProdutos();
  }
  /*
  recuperarProdutos() {
    this.produtosService.listarProdutos(this.request).subscribe((produtos) => {
      this.produtos = produtos;
    });
  }

  trocarPagina(pagina: number) {
    this.request.Pg = pagina;
    this.recuperarProdutos();
  }

  trocarQuantidade(quantidade: number) {
    this.request.Qt = quantidade;
    this.recuperarProdutos();
  }
  */
}
