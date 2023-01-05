import { CarrinhosService } from './../../../shared/services/carrinhos.service';
import { CarrinhoResponse } from 'src/app/shared/models/responses/carrinho.response';
import { Component, Input, OnInit } from '@angular/core';
import { ProdutoResponse } from 'src/app/shared/models/responses/produto.response';

@Component({
  selector: 'app-finalizacao-outros',
  templateUrl: './finalizacao-outros.component.html',
  styleUrls: ['./finalizacao-outros.component.css']
})
export class FinalizacaoOutrosComponent implements OnInit {

  @Input()
  carrinhos: CarrinhoResponse[] = [];
  @Input()
  produtosRelacionados: ProdutoResponse[] = [];
  valorTotal!: number;

  constructor(
  ) { }

  ngOnInit(): void {
  }

  calcularValorTotal(){
    let total = 0;

    this.carrinhos.forEach(carrinho => {
      let valor = carrinho.produto.valor * carrinho.quantidade;

      total += valor;
    });
    return total;
  }

}
