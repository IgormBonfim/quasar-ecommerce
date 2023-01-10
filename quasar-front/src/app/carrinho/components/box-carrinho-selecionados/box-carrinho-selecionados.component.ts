import { CarrinhoResponse } from './../../../shared/models/responses/carrinho.response';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { faTrash } from '@fortawesome/free-solid-svg-icons';
import { CarrinhosService } from 'src/app/shared/services/carrinhos.service';
import { EstoquesService } from 'src/app/shared/services/estoques.service';
import { EstoqueResponse } from 'src/app/shared/models/responses/estoque.response';

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
    private carrinhosService: CarrinhosService,
    private estoquesService: EstoquesService
  ) { }

  ngOnInit(): void {
    this.recuperarDoEstoque(this.carrinho.produto.codigo);
  }

  removerProdutoCarrinho(codigo: number) {
    this.carrinhosService
    .remover(codigo)
    .subscribe({
      next: () => {
        this.lixo.emit(true)
      }
    })
  }

  recuperarDoEstoque(codigo: number) {
    this.estoquesService.recuperarEstoquePeloCodigoDoProduto(codigo).subscribe({
      next: (res: EstoqueResponse) => {
        this.disponivel = res.quantidade > 0;
      }
    })
  }
}
