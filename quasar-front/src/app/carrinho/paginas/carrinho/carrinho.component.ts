import { PaginacaoRequest } from './../../../shared/models/requests/paginacao.request';
import { CarrinhosService } from './../../../shared/services/carrinhos.service';
import { PaginacaoResponse } from 'src/app/shared/models/responses/paginacao.response';
import { Component, OnInit } from '@angular/core';
import { CarrinhoResponse } from 'src/app/shared/models/responses/carrinho.response';

@Component({
  selector: 'app-carrinho',
  templateUrl: './carrinho.component.html',
  styleUrls: ['./carrinho.component.css']
})
export class CarrinhoComponent implements OnInit {
  public produtosCarrinho!: PaginacaoResponse<CarrinhoResponse>;
  public request = new PaginacaoRequest({
    quantidade: 9999
  })


  constructor(private readonly carrinhosService: CarrinhosService) { }

  ngOnInit(): void {
    this.recuperarCarrinhos();
  }

  recuperarCarrinhos(){
    this.carrinhosService.listar(this.request).subscribe({
      next: (res: PaginacaoResponse<CarrinhoResponse>) => {
        this.produtosCarrinho = res;
        console.log(res);
      }
    })
  }
}
