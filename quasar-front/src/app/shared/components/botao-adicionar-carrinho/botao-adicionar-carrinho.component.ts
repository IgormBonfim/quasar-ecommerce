import { Component, Input, OnInit } from '@angular/core';
import { faCartShopping } from '@fortawesome/free-solid-svg-icons';
import { CarrinhoInserirRequest } from '../../models/requests/carrinhoInserir.request';
import { CarrinhosService } from '../../services/carrinhos.service';

@Component({
  selector: 'app-botao-adicionar-carrinho',
  templateUrl: './botao-adicionar-carrinho.component.html',
  styleUrls: ['./botao-adicionar-carrinho.component.css']
})
export class BotaoAdicionarCarrinhoComponent implements OnInit {

  @Input()
  public codigo!: number;

  public carregando!: boolean;
  public iconeCarrinho = faCartShopping;


  constructor(
    private carrinhosService: CarrinhosService
    ) { }

  ngOnInit(): void {
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
