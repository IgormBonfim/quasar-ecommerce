import { CarrinhoInserirRequest } from './../../models/requests/carrinhoInserir.request';
import { CarrinhosService } from './../../services/carrinhos.service';
import { ProdutoResponse } from './../../models/responses/produto.response';
import { Component, Input, OnInit } from '@angular/core';
import { faCartShopping } from '@fortawesome/free-solid-svg-icons';
import { faHeart } from '@fortawesome/free-regular-svg-icons';

@Component({
  selector: 'app-produto-card',
  templateUrl: './produto-card.component.html',
  styleUrls: ['./produto-card.component.css']
})
export class ProdutoCardComponent implements OnInit {

  @Input()
  public produto! : ProdutoResponse;

  public iconeCoracaoCheio = faHeart;
  public iconeCarrinho = faCartShopping;
  public favorito = false;
  public carregando!: boolean;
  constructor(
    private carrinhosService: CarrinhosService
  ) { }

  ngOnInit(): void {
  }

  favoritar(codigo: number) {
    this.favorito = !this.favorito;
  }

  adicionarAoCarrinho(codigo: number) {
    this.carregando = true;

    let body = new CarrinhoInserirRequest(1, codigo);

    this.carrinhosService.adicionar(body).subscribe({
      next: response => {
        this.carregando = false;
      },
      error: (reason) => {
        console.error(reason);
        this.carregando = false;
      }
    })

  }

}
