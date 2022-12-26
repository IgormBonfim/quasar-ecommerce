import { Router } from '@angular/router';
import { HttpErrorResponse } from '@angular/common/http';
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
    private carrinhosService: CarrinhosService,
    private router: Router
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
      error: (reason : HttpErrorResponse) => {
        console.error(reason);
        if (reason.status == 401) {
          this.router.navigate(['login']);
        }
        this.carregando = false;
      }
    })

  }

}
