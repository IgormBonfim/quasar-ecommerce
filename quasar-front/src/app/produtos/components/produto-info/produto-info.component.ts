import { Router } from '@angular/router';
import { HttpErrorResponse } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import { faHeart } from '@fortawesome/free-regular-svg-icons';
import { faCreditCard, faMoneyBill, faShareNodes, faCartShopping } from '@fortawesome/free-solid-svg-icons';
import { FavoritoRequest } from 'src/app/shared/models/requests/favorito.request';

import { ProdutoResponse } from './../../../shared/models/responses/produto.response';
import { FavoritosService } from './../../../shared/services/favoritos.service';
import { CarrinhoInserirRequest } from 'src/app/shared/models/requests/carrinhoInserir.request';
import { CarrinhosService } from 'src/app/shared/services/carrinhos.service';
import { AlertsService, AlertTypes } from 'src/app/shared/services/alerts.service';

@Component({
  selector: 'app-produto-info',
  templateUrl: './produto-info.component.html',
  styleUrls: ['./produto-info.component.css']
})
export class ProdutoInfoComponent implements OnInit {

  public favorito: boolean = false;
  public iconeCoracaoVazio = faHeart;
  public iconeShare = faShareNodes;
  public iconeDinheiro = faMoneyBill;
  public iconeCartao = faCreditCard;
  public iconeCarrinho = faCartShopping;

  @Input()
  public produtoDetalhe!: ProdutoResponse;
  @Input()
  public produtoDisponivel!: boolean;
  public quantidade: number = 1;

  constructor(
    private favoritosService: FavoritosService,
    private carrinhosService: CarrinhosService,
    private alertsService: AlertsService,
    private router: Router
    ) { }

  ngOnInit(): void {
  }

  removerFavorito(codigo: number) {
    let request = new FavoritoRequest(codigo)

    this.favoritosService.removerFavorito(request).subscribe({
      next: () => {
        this.favorito = false;
      },
      error: (erro: HttpErrorResponse) => {
        if (erro.status == 401) {
          this.router.navigate(['login']);
        }
      }
    })
  }

  adicionarFavorito(codigo: number) {
    let request = new FavoritoRequest(codigo)

    this.favoritosService.adicionarFavorito(request).subscribe({
      next: () => {
        this.favorito = true;
      },
      error: (erro: HttpErrorResponse) => {
        if (erro.status == 401) {
          this.router.navigate(['login']);
        }
      }
    })
  }

  adicionarAoCarrinho() {
    let codigo = this.produtoDetalhe.codigo;
    let quantidade = this.quantidade;

    let request = new CarrinhoInserirRequest(quantidade, codigo);

    this.carrinhosService.adicionar(request).subscribe({
      next: () => {
        this.alertsService.adicionarAlerta(
          "Sucesso",
          "Produto adicionado ao carrinho",
          AlertTypes.SUCESSO
        )
      },
      error: (erro: HttpErrorResponse) => {
        if (erro.status == 401) {
          this.router.navigate(['login']);
        }
        else {
          this.alertsService.adicionarExcecao(erro.error)
        }
      }
    })

  }

  mudarQuantidade(valor: number) {
    this.quantidade = valor;
  }

}
