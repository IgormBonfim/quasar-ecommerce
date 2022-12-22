import { HttpErrorResponse } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { faHeart } from '@fortawesome/free-regular-svg-icons';

import { FavoritoRequest } from './../../models/requests/favorito.request';
import { ProdutoResponse } from './../../models/responses/produto.response';
import { FavoritosService } from './../../services/favoritos.service';

@Component({
  selector: 'app-produto-card',
  templateUrl: './produto-card.component.html',
  styleUrls: ['./produto-card.component.css']
})
export class ProdutoCardComponent implements OnInit {

  @Input()
  public produto! : ProdutoResponse;

  public iconeCoracaoVazio = faHeart;
  public favorito = false;
  constructor(
    private favoritosService: FavoritosService,
    private router: Router
  ) { }

  ngOnInit(): void {
  }

  adicionarFavorito(codigo: number) {
    let favorito = new FavoritoRequest(codigo);

    this.favoritosService.removerFavorito(favorito).subscribe({
      next: response => {
        this.favorito = true;
      },
      error: (reason : HttpErrorResponse) => {
        console.error(reason);
        if (reason.status == 401) {
          this.router.navigate(['login']);
        }
      }
    })
  }

  removerFavorito(codigo: number) {
    this.favorito = false;
  }
}
