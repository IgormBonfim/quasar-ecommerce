import { Component, OnInit } from '@angular/core';

import { PaginacaoRequest } from '../../models/requests/paginacao.request';
import { PaginacaoResponse } from './../../models/responses/paginacao.response';
import { ProdutoResponse } from './../../models/responses/produto.response';
import { ProdutosService } from './../../services/produtos.service';

@Component({
  selector: 'app-carrosel-de-produto',
  templateUrl: './carrosel-de-produto.component.html',
  styleUrls: ['./carrosel-de-produto.component.css']
})
export class CarroselDeProdutoComponent implements OnInit {

  request = new PaginacaoRequest({
    quantidade: 10
  });
  produtos!: PaginacaoResponse<ProdutoResponse>;

  responsiveOptions = [

    {
        breakpoint: '1024px',
        numVisible: 3,
        numScroll: 3
    },
    {
        breakpoint: '768px',
        numVisible: 2,
        numScroll: 2
    },
    {
        breakpoint: '560px',
        numVisible: 1,
        numScroll: 1
    }
];

  constructor(private readonly produtosService: ProdutosService) { }

  ngOnInit(): void {
    this.produtosService.listarProdutos(this.request).subscribe({
      next: (res: PaginacaoResponse<ProdutoResponse>) => {
        this.produtos = res;
      }
    })
  }

}
