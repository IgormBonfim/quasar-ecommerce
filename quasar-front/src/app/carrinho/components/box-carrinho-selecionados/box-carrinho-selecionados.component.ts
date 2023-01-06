import { CarrinhoResponse } from './../../../shared/models/responses/carrinho.response';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { faTrash } from '@fortawesome/free-solid-svg-icons';
import { CarrinhosService } from 'src/app/shared/services/carrinhos.service';

@Component({
  selector: 'app-box-carrinho-selecionados',
  templateUrl: './box-carrinho-selecionados.component.html',
  styleUrls: ['./box-carrinho-selecionados.component.css']
})
export class BoxCarrinhoSelecionadosComponent implements OnInit {

  iconeLixo = faTrash

  disponivel: boolean = true;

  @Input()
  carrinho!: CarrinhoResponse;

  @Output()
  lixo = new EventEmitter<boolean>();

  constructor(
    private carrinhosService: CarrinhosService
  ) { }

  ngOnInit(): void {
  }

  removerProdutoCarrinho(codigo: number) {
    console.log(codigo);
    this.carrinhosService
    .remover(codigo)
    .subscribe({
      next: () => {
        this.lixo.emit(true)
      }
    })
  }
}
