import { CarrinhoInserirRequest } from './../../../shared/models/requests/carrinhoInserir.request';
import { CarrinhosService } from './../../../shared/services/carrinhos.service';
import { CarrinhoResponse } from 'src/app/shared/models/responses/carrinho.response';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ProdutoResponse } from 'src/app/shared/models/responses/produto.response';
import { BotaoAdicionarCarrinhoComponent } from 'src/app/shared/components/botao-adicionar-carrinho/botao-adicionar-carrinho.component';

@Component({
  selector: 'app-finalizacao-outros',
  templateUrl: './finalizacao-outros.component.html',
  styleUrls: ['./finalizacao-outros.component.css'],
})
export class FinalizacaoOutrosComponent implements OnInit {
  @Output()
  produtoAdicionado = new EventEmitter<boolean>();
  @Input()
  carrinhos: CarrinhoResponse[] = [];
  @Input()
  produtosRelacionados: ProdutoResponse[] = [];
  valorTotal!: number;


  constructor(private readonly service: CarrinhosService) {}

  ngOnInit(): void {}

  colocarCarrinho(codProduto: number) {
    let request = new CarrinhoInserirRequest(1, codProduto);
    this.service.adicionar(request).subscribe({
      next: res => {
        this.produtoAdicionado.emit(true);
      }
    });
  }

  calcularValorTotal() {
    let total = 0;

    this.carrinhos.forEach((carrinho) => {
      let valor = carrinho.produto.valor * carrinho.quantidade;

      total += valor;
    });
    return total;
  }
}
