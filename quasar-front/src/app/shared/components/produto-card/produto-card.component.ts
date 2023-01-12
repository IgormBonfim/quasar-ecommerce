import { HttpErrorResponse } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { faHeart } from '@fortawesome/free-regular-svg-icons';
import { AlertsService, AlertTypes } from '../../services/alerts.service';

import { FavoritoRequest } from './../../models/requests/favorito.request';
import { ProdutoResponse } from './../../models/responses/produto.response';
import { FavoritosService } from './../../services/favoritos.service';

@Component({
  selector: 'app-produto-card',
  templateUrl: './produto-card.component.html',
  styleUrls: ['./produto-card.component.css'],
})
export class ProdutoCardComponent implements OnInit {
  @Input()
  public produto!: ProdutoResponse;

  public iconeCoracaoVazio = faHeart;
  public favorito = false;
  constructor(
    private favoritosService: FavoritosService,
    private alertsService: AlertsService,
    private router: Router
  ) {}

  ngOnInit(): void {}

  adicionarFavorito(codigo: number) {
    let favorito = new FavoritoRequest(codigo);

    this.favoritosService.adicionarFavorito(favorito).subscribe({
      next: () => {
        this.favorito = true;
        this.alertsService.adicionarAlerta(
          "Sucesso",
          "Produto adicionado aos favoritos",
          AlertTypes.SUCESSO
        )
      },
      error: (reason: HttpErrorResponse) => {
        if (reason.status == 401) {
          this.router.navigate(['login']);
        }
        else {
          this.alertsService.adicionarExcecao(reason.error);
        }
      },
    });
  }

  removerFavorito(codigo: number) {
    let favorito = new FavoritoRequest(codigo);

    this.favoritosService.removerFavorito(favorito).subscribe({
      next: () => {
        this.favorito = false;
        this.alertsService.adicionarAlerta(
          "Sucesso",
          "Produto removido dos favoritos",
          AlertTypes.SUCESSO
        )
      },
      error: (reason: HttpErrorResponse) => {
        console.error(reason);
        if (reason.status == 401) {
          this.router.navigate(['login']);
        }
        else {
          this.alertsService.adicionarExcecao(reason.error);
        }
      },
    });
  }
}
